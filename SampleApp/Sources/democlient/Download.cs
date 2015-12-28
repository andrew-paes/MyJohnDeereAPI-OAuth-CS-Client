using Hammock.Authentication.OAuth;
using Hammock.Web;
using SampleApp.Sources.democlient.rest;
using SampleApp.Sources.generated.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleApp.Sources.democlient
{
    class Download
    {
        private Dictionary<String, Link> links;
        private CollectionPage<SampleApp.Sources.generated.v3.File> files;
        private String firstFileSelfUri;
        private String filename;
        private long fileSize;
        private byte[] md5FromSinglePieceDownload;

        private byte[] md5FromMultiplePieceDownload;

        private Hammock.RestClient getRestClient()
        {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
                ApiCredentials.TOKEN.secret, null, null);

            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };
            return client;

        }

        public void retrieveApiCatalog()
        {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
                ApiCredentials.TOKEN.secret, null, null);


            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = "https://apicert.soa-proxy.deere.com/platform/"
            };

            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
            Hammock.RestResponse response = client.Request(request);

            ApiCatalog apiCatalog = Deserialise<ApiCatalog>(response.ContentStream);
 
            links = OAuthWorkFlow.linksFrom(apiCatalog);

            getFiles();

            retrieveMetadataForFile();

           downloadFileContentsAndComputeMd5();
           //downloadFileInPiecesAndComputeMd5();
        }

        public void getFiles() {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
                ApiCredentials.TOKEN.secret, null, null);


            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = links["files"].uri
            };

            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
            Hammock.RestResponse response = client.Request(request);

            CollectionPageDeserializer ds = new CollectionPageDeserializer();

            files = ds.deserialize<SampleApp.Sources.generated.v3.File>(response.Content);

     }

        public void retrieveMetadataForFile() {

            generated.v3.File fileForMetaData = getValidFile(files);
            Dictionary<String, Link> linksFromFirstFile = OAuthWorkFlow.linksFrom(fileForMetaData);
            
            firstFileSelfUri = linksFromFirstFile["self"].uri;
            
            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
                ApiCredentials.TOKEN.secret, null, null);


            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = firstFileSelfUri
            };

            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
            Hammock.RestResponse response = client.Request(request);

            SampleApp.Sources.generated.v3.File firstFileDetails = Deserialise<SampleApp.Sources.generated.v3.File>(response.ContentStream);

            filename = firstFileDetails.name;
            fileSize = firstFileDetails.nativeSize;
            System.Diagnostics.Debug.WriteLine("File Name:" + filename + " \n File Size:" + fileSize);
    }

        private generated.v3.File getValidFile(CollectionPage<generated.v3.File> files)
        {
            generated.v3.File fileForMetaData = null;
            for (int i = 0; i < files.page.Count; i++)
            {
                if (files.page[i].type != "INVALID" || files.page[i].type != "UNKNOWN")
                {
                    fileForMetaData = files.page[i];
                    break;
                }
            }
            if (fileForMetaData == null) {
                System.Diagnostics.Debug.WriteLine(" No Files to download");
            }
        return fileForMetaData;
        }

        public void downloadFileContentsAndComputeMd5() {

            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
                ApiCredentials.TOKEN.secret, null, null);


            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = firstFileSelfUri
            };

            request.AddHeader("Accept", "application/zip");
            Hammock.RestResponse response = client.Request(request);


            using (Stream output = System.IO.File.OpenWrite("C:\\"+filename))
            using (Stream input = response.ContentStream)
            {
                input.CopyTo(output);
            }
        }

        public void downloadFileInPiecesAndComputeMd5() {
            //Max file size for download is 50 MB
            long maxFileSize = 52428800;
            long start = 0;
            long end = fileSize <= maxFileSize ? fileSize : maxFileSize;
            if(!System.IO.File.Exists("C:\\"+filename)) {
                System.IO.File.Create("C:\\"+filename).Dispose();
            }
            using (Stream output = System.IO.File.OpenWrite("C:\\" + filename))

            getChunkFromStartAndRecurse(0, end, fileSize, output);
            
            System.Diagnostics.Debug.WriteLine("File Name = " + filename);
            System.Diagnostics.Debug.WriteLine("File Size(KB) = " + fileSize / 1024.0);
        }

        private void getChunkFromStartAndRecurse( long start, long chunkSize, long fileSize, Stream output) {
             long maxRange = fileSize - 1;
             long end = Math.Min(start + chunkSize, maxRange);
             chunkSize = start + chunkSize < maxRange ? chunkSize : fileSize - start;

             Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
             ApiCredentials.TOKEN.secret, null, null);
             Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = firstFileSelfUri,
                Method = WebMethod.Get
            };
            request.AddHeader("Accept", "application/zip");
            request.AddParameter("offset", "" + start);
            request.AddParameter("size", "" + chunkSize);
            Hammock.RestResponse response = client.Request(request);
            using (Stream input = response.ContentStream)
            {
                input.CopyTo(output);
            }
            if (start + chunkSize < maxRange) {
                getChunkFromStartAndRecurse(end, chunkSize, fileSize, output);
            }
        }

     public static T Deserialise<T>(Stream stream)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            T result = (T)deserializer.ReadObject(stream);
            return result;
        }
    }
}
