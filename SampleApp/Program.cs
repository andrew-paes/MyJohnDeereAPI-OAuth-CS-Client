using System;
using System.Collections.Generic;
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
            // Check out the RestClient source for how to use the oAuth token to sign requests
            var restClient = new RestClient(apiCredentials);
            var apiCatalog = GetApiCatalog(restClient);

            var apiExamples = new ApiExamples(apiCredentials);
            var organizationsLink = apiCatalog.links.Single(link => link.rel == "organizations");
            var organizations = apiExamples.GetAllUsingPagination<Organization>(organizationsLink.uri);
            GetAllFilesUsingDetags(organizations, apiExamples);
        }

        private static void GetAllFilesUsingDetags(IEnumerable<Organization> organizations, ApiExamples apiExamples)
        {
            foreach (var org in organizations)
            {
                var filesApiUrl = org.links.Single(link => link.rel == "files").uri;

                // The first time, we don't have a Deere ETag value. Pass null -- it will return the entire list without pagination, and give you an ETag
                var filesResult = apiExamples.GetListUsingDetag<File>(filesApiUrl, null);

                // Save this Deere ETag value. It is tied to this URI (which also means it is specific to this Organization). You can use it later in order
                // to only receive data that is new or modified since you last made this call, instead of having to download the entire list again.
                var detagValue = filesResult.Item1;
                var allFilesForOrganization = filesResult.Item2;

                // This call will probably return an HTTP 304 (Not Modified), generating an empty list. It will only return data that was created or modified 
                // since your last call.
                var newFilesSinceLastApiCall = apiExamples.GetListUsingDetag<File>(filesApiUrl, detagValue).Item2;
            }
        }

        private static ApiCatalog GetApiCatalog(RestClient restClient)
        {
            // The API Catalog is a collection of links to other available MyJohnDeere API's.
            // It's an easy place to discover other API's that look interesting, or just explore what's available.
            var restRequest = new RestRequest
            {
                Url = "https://sandboxapi.deere.com/platform/",
                Method = HttpMethod.Get
            };
            var response = restClient.Execute(restRequest);
            var apiCatalog = response.GetResponseAsObject<ApiCatalog>();
            
            apiCatalog.links.ForEach(link => Console.WriteLine($"{link.rel}: {link.uri}"));

            return apiCatalog;
        }
    }
}
