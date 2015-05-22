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
        private byte[] md5FromSinglePieceDownload;

        private byte[] md5FromMultiplePieceDownload;

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
            downloadFileInPiecesAndComputeMd5();
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

            Console.WriteLine("done");

     }

        public void retrieveMetadataForFile() {

            Dictionary<String,Link> linksFromFirstFile = OAuthWorkFlow.linksFrom(files.page[3]);

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


            checkFilenameInContentDispositionHeader(response);

            using (var md5 = MD5.Create())
            {
                using (var stream = response.ContentStream)
                {
                    md5FromSinglePieceDownload =  md5.ComputeHash(stream);
                }
            }
        }

        private void checkFilenameInContentDispositionHeader( Hammock.RestResponse fileDetailsResponse) {
            String contentDispositionHeader = "Content-Disposition";
            //checkThat("Content-Disposition header set?", fileDetailsResponse.getHeaderFields().contains(contentDispositionHeader), isTrue());
            String contentDisposition = fileDetailsResponse.Headers[contentDispositionHeader];
            if (contentDisposition != null) {
                Regex r = new Regex(contentDispositionHeader, RegexOptions.IgnoreCase);

                // Match the regular expression pattern against a text string.
                Match m = r.Match(contentDisposition);
                int matchCount = 0;
                if (m.Success) {
                    ///checkThat("filename as reported by API", matcher.group(2), isEqualTo(filename));
                }
        }
    }

        public void downloadFileInPiecesAndComputeMd5() {
             int fileSize = makeHeadRequestToGetFileSize();

             int numberOfChunks = 2;
             int chunkSize = (fileSize / numberOfChunks) - 1;
             
            //DigestOutputStream byteDigest = new DigestOutputStream(nullOutputStream(), getInstance("md5"));

            getChunkFromStartAndRecurse(0, chunkSize, fileSize);

            //checkThat("md5 digest", byteDigest.getMessageDigest().digest(), isEqualTo(md5FromSinglePieceDownload));
    }

    private int makeHeadRequestToGetFileSize() {
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
                Method = WebMethod.Head
            };

            request.AddHeader("Accept", "application/zip");
            Hammock.RestResponse response = client.Request(request);
        /*if (!hasResponseCode(OK).matches(headRes)) {
            firstFileSelfUri = null;
            //fail(format("HEAD request to %s returned bad response code", firstFileSelfUri));
        }*/
        //checkThat("Content-Length header", headRes.getHeaderFields().contains("Content-Length"), isTrue());
            return Convert.ToInt32(response.Headers["Content-Length"]);
        //return Integer.valueOf(headRes.getHeaderFields().valueOf("Content-Length"));
    }

        private void getChunkFromStartAndRecurse( int start, int chunkSize, int fileSize
                                                         //,DigestOutputStream byteDigest
            ) {
         int maxRange = fileSize - 1;
         int end = Math.Min(start + chunkSize, maxRange);

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
            request.AddHeader("Range", "bytes=" + start + "-" + end );
            Hammock.RestResponse response = client.Request(request);


            using (var md5 = MD5.Create())
            {
                using (var stream = response.ContentStream)
                {
                    md5FromMultiplePieceDownload = md5.ComputeHash(stream);
                }
            }

        checkFilenameInContentDispositionHeader(response);

       // copy(rangeResponse.getBody(), byteDigest);

        if (start + chunkSize < maxRange) {
            getChunkFromStartAndRecurse(start + chunkSize + 1, chunkSize, fileSize);
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
