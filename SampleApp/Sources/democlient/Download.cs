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


        private Hammock.RestClient getRestClient()
        {
//            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
//                ApiCredentials.TOKEN.secret, null, null);
//
//            Hammock.RestClient client = new Hammock.RestClient()
//            {
//                Authority = "",
//                Credentials = credentials
//            };
//            return client;
            return null;

        }

        public void retrieveApiCatalog()
        {
//            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
//                ApiCredentials.TOKEN.secret, null, null);
//
//
//            Hammock.RestClient client = new Hammock.RestClient()
//            {
//                Authority = "",
//                Credentials = credentials
//            };
//
//            Hammock.RestRequest request = new Hammock.RestRequest()
//            {
//                Path = "https://sandboxapi.deere.com/platform/"
//            };
//
//            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
//            Hammock.RestResponse response = client.Request(request);
//
//            ApiCatalog apiCatalog = Deserialise<ApiCatalog>(response.ContentStream);
// 
//            links = OAuthWorkFlow.linksFrom(apiCatalog);
//
//            getFiles();
//
//            retrieveMetadataForFile();
//            downloadFileInPiecesAndComputeMd5();
        }

        public void getFiles() {
//            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
//                ApiCredentials.TOKEN.secret, null, null);
//
//
//            Hammock.RestClient client = new Hammock.RestClient()
//            {
//                Authority = "",
//                Credentials = credentials
//            };
//
//            Hammock.RestRequest request = new Hammock.RestRequest()
//            {
//                Path = links["files"].uri
//            };
//
//            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
//            Hammock.RestResponse response = client.Request(request);
//
//            CollectionPageDeserializer ds = new CollectionPageDeserializer();
//
//            files = ds.deserialize<SampleApp.Sources.generated.v3.File>(response.Content);

     }

        public void retrieveMetadataForFile() {

//            generated.v3.File fileForMetaData = getValidFile(files);
//            Dictionary<String, Link> linksFromFirstFile = OAuthWorkFlow.linksFrom(fileForMetaData);
//            
//            firstFileSelfUri = linksFromFirstFile["self"].uri;
//            
//            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
//                ApiCredentials.TOKEN.secret, null, null);
//
//
//            Hammock.RestClient client = new Hammock.RestClient()
//            {
//                Authority = "",
//                Credentials = credentials
//            };
//
//            Hammock.RestRequest request = new Hammock.RestRequest()
//            {
//                Path = firstFileSelfUri
//            };
//
//            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
//            Hammock.RestResponse response = client.Request(request);
//
//            SampleApp.Sources.generated.v3.File firstFileDetails = Deserialise<SampleApp.Sources.generated.v3.File>(response.ContentStream);
//
//            filename = firstFileDetails.name;
//            fileSize = firstFileDetails.nativeSize;
//            System.Diagnostics.Debug.WriteLine("File Name:" + filename + " \n File Size:" + fileSize);
    }

        private generated.v3.File getValidFile(CollectionPage<generated.v3.File> files)
        {
            generated.v3.File fileForMetaData = null;
            for (int i = 0; i < files.page.Count; i++)
            {
                if (files.page[i].type != "INVALID" && files.page[i].type != "UNKNOWN")
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

 
        public void downloadFileInPiecesAndComputeMd5() {
            //Max file size for download is 50 MB
            long maxFileSize = 16 * 1024 * 1024;
            long end = fileSize <= maxFileSize ? fileSize : maxFileSize;
            if(!System.IO.File.Exists("C:\\"+filename)) {
                System.IO.File.Create("C:\\"+filename).Dispose();
            }
            using (Stream output = System.IO.File.OpenWrite("C:\\" + filename))
            getChunkFromStartAndRecurse(0, end, fileSize, output);
        }

        private void getChunkFromStartAndRecurse(long start, long chunkSize, long fileSize, Stream output) {
           if(fileSize <= chunkSize)
            {
                createDownloadRequest(start, fileSize, output);
            }
            else
            {
                createDownloadRequest(start, chunkSize, output);
                getChunkFromStartAndRecurse(start + chunkSize, chunkSize, fileSize - chunkSize, output);
            }
        }

        private void createDownloadRequest(long start, long bytesToRead, Stream output)
        {
//            Hammock.Authentication.OAuth.OAuthCredentials credentials = OAuthWorkFlow.createOAuthCredentials(OAuthType.ProtectedResource, ApiCredentials.TOKEN.token,
//            ApiCredentials.TOKEN.secret, null, null);
//            Hammock.RestClient client = new Hammock.RestClient()
//            {
//                Authority = "",
//                Credentials = credentials
//            };
//
//            Hammock.RestRequest request = new Hammock.RestRequest()
//            {
//                Path = firstFileSelfUri,
//                Method = WebMethod.Get
//            };
//            request.AddHeader("Accept", "application/zip");
//            request.AddParameter("offset", "" + start);
//            request.AddParameter("size", "" + bytesToRead);
//            Hammock.RestResponse response = client.Request(request);
//            using (Stream input = response.ContentStream)
//            {
//                input.CopyTo(output);
//            }
        }

     public static T Deserialise<T>(Stream stream)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            T result = (T)deserializer.ReadObject(stream);
            return result;
        }
    }
}
