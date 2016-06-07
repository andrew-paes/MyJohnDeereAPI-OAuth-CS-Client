using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Sources.generated.v3;
using System.IO;
using System.Runtime.Serialization.Json;
using Hammock.Authentication.OAuth;
using System.Compat.Web;

namespace SampleApp.Sources.democlient
{
    class OAuthWorkFlow
    {
        private String authUri;
        private String verifier;
        Dictionary<String, Link> links;
        String reqToken ;
        String reqSecret;

        public void retrieveApiCatalogToEstablishOAuthProviderDetails()
        {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = createOAuthCredentials(OAuthType.ProtectedResource, null, null, null, null);
          
            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "https://sandboxapi.deere.com/platform/",
                Credentials = credentials
            };
            
            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = ""
            };

            request.AddHeader("Accept", "application/vnd.deere.axiom.v3+json");
            Hammock.RestResponse response = client.Request(request);

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ApiCatalog));

            stream1.Position = 0;
            ApiCatalog apiCatalog = (ApiCatalog)ser.ReadObject(response.ContentStream);

            links = linksFrom(apiCatalog);

        }

         public static Dictionary<String, Link> linksFrom(Resource res) {
                
             Dictionary<String, Link> map = new Dictionary<String, Link>();
             
             foreach(Link link in res.links) {
                 map.Add(link.rel, link);
             }
             return map;
        }

         public void getRequestToken() 
         {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = createOAuthCredentials(OAuthType.RequestToken, null, null, null, "oob");
           
            
             Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = links["oauthRequestToken"].uri
            };

            Hammock.RestResponse response = client.Request(request);

            reqToken = response.Content.Split('&')[0];
            

            authUri = cleanAuthorizationUri(links["oauthAuthorizeRequestToken"].uri) + "?" + reqToken;
            reqToken =reqToken.Split('=')[1];
            reqSecret = response.Content.Split('&')[1].Split('=')[1];

        }

        
         public void authorizeRequestToken() {
            Console.WriteLine("Please provide the verifier from "  + authUri);
            verifier = Console.ReadLine();

        }

         public void exchangeRequestTokenForAccessToken() {
            Hammock.Authentication.OAuth.OAuthCredentials credentials = createOAuthCredentials(OAuthType.AccessToken, reqToken, HttpUtility.UrlDecode(reqSecret), verifier, null);
                  
          
            Hammock.RestClient client = new Hammock.RestClient()
            {
                Authority = "",
                Credentials = credentials
            };

            Hammock.RestRequest request = new Hammock.RestRequest()
            {
                Path = links["oauthAccessToken"].uri
            };

            Hammock.RestResponse response = client.Request(request);

            Console.WriteLine("Token:" + response.Content.Split('&')[0].Split('=')[1] + " \n Token Secret:" + response.Content.Split('&')[1].Split('=')[1]);
            String oauthToken = response.Content.Split('&')[0].Split('=')[1];
            String oauthTokenSecret = response.Content.Split('&')[1].Split('=')[1];

            System.Diagnostics.Debug.WriteLine("Token:" + oauthToken + " \n Token Secret:" + HttpUtility.UrlDecode(oauthTokenSecret));
        }

        private static String cleanAuthorizationUri(String uri) {
            return uri.Substring(0, uri.IndexOf("?"));
        }


        public static Hammock.Authentication.OAuth.OAuthCredentials createOAuthCredentials(OAuthType type, String strToken, String strSecret, String strVerifier, String strCallBack ){
            Hammock.Authentication.OAuth.OAuthCredentials credentials = new Hammock.Authentication.OAuth.OAuthCredentials()
            {
                Type =type,
                SignatureMethod = Hammock.Authentication.OAuth.OAuthSignatureMethod.HmacSha1,
                ParameterHandling = Hammock.Authentication.OAuth.OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = SampleApp.Sources.democlient.ApiCredentials.CLIENT.key,
                ConsumerSecret = SampleApp.Sources.democlient.ApiCredentials.CLIENT.secret,
                Token = strToken,
                TokenSecret = strSecret,
                Verifier = strVerifier,
                CallbackUrl = strCallBack
            };
            return credentials;

        }

        


    }
}
