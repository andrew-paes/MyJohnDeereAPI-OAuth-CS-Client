using System;
using System.Net.Http;
using SampleApp.Sources.democlient;
using SampleApp.Sources.democlient.rest;
using SampleApp.Sources.generated.v3;

namespace SampleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // Please paste your App Id and Shared Secret from your application profile on https://developer.deere.com
            string clientKey = "Your application's 'App ID' from developer.deere.com";
            string clientSecret = "Your application's 'Shared Secret' from developer.deere.com";

            var oauthWorkflowExample = new OAuthWorkFlow();
            // We currently support oAuth 1.0. You can dig in to the authentication code for an example using the
            // open source DevDefined.OAuth libraries.
            var apiCredentials = oauthWorkflowExample.Authenticate(clientKey, clientSecret);

            // Now let's inject the credentials into our rest client and make some API calls
            // Check out the RestClient source for how to use the oAuth token to sign requests
            var restClient = new RestClient(apiCredentials);
            GetApiCatalog(restClient);
        }

        private static void GetApiCatalog(RestClient restClient)
        {
            // The API Catalog is a collection of links to other available MyJohnDeere API's.
            // It's an easy place to discover other API's that look interesting, or just explore what's available.
            var restRequest = new RestRequest
            {
                Url = "https://sandboxapi.deere.com/platform/",
                Method = HttpMethod.Get
            };
            var response = restClient.Execute(restRequest);
            var apiCatalog = new Serializer().Deserialize<ApiCatalog>(response.GetBody());
            
            apiCatalog.links.ForEach(link => Console.WriteLine($"{link.rel}: {link.uri}"));
        }
    }
}
