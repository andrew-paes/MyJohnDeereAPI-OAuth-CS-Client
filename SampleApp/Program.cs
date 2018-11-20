using System;
using System.Linq;
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
            // Check out the OAuthSignedRestClient source for how to use the oAuth token to sign requests
            var oauthRestClient = new OAuthSignedRestClient(apiCredentials);
            var apiCatalog = GetApiCatalog(oauthRestClient);

            var apiClient = new ApiClient(apiCredentials);
            var organizationsLink = apiCatalog.links.Single(link => link.rel == LinkRel.organizations.ToString());
            var organizations = apiClient.GetAllUsingPagination<Organization>(organizationsLink.uri).ToList();

            // Examples of downloading all files using Detags, and uploading a new file
            new FilesApiExamples(apiClient).MakeFilesApiCalls(organizations);
            // How to get all fields for an organization, optionally embedding clients, farms, and boundaries
            new FieldsApiExamples(apiClient).MakeFieldsApiCalls(organizations);
        }

        private static ApiCatalog GetApiCatalog(OAuthSignedRestClient oAuthSignedRestClient)
        {
            // The API Catalog is a collection of links to other available MyJohnDeere API's.
            // It's an easy place to discover other API's that look interesting, or just explore what's available.
            var restRequest = new RestRequest
            {
                Url = "https://sandboxapi.deere.com/platform/",
                Method = HttpMethod.Get
            };
            var response = oAuthSignedRestClient.Execute(restRequest);
            var apiCatalog = response.GetResponseAsObject<ApiCatalog>();
            
            apiCatalog.links.ForEach(link => Console.WriteLine($"{link.rel}: {link.uri}"));

            return apiCatalog;
        }
    }
}
