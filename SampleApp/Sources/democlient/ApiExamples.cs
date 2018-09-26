using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using SampleApp.Sources.democlient.rest;

namespace SampleApp.Sources.democlient
{
    public class ApiExamples
    {
        private readonly RestClient _restClient;

        public ApiExamples(ApiCredentials credentials)
        {
            _restClient = new RestClient(credentials);
        }

        public IEnumerable<T> GetAllUsingPagination<T>(string endpointUrl)
        {
            var restRequest = new RestRequest
            {
                Url = endpointUrl,
                Method = HttpMethod.Get
            };
            do
            {
                var response = _restClient.Execute(restRequest);
                var resultPage = response.GetResponsePage<T>();
                if (resultPage?.page == null)
                    yield break;
                foreach (var returnedElement in resultPage.page)
                {
                    yield return returnedElement;
                }
                restRequest.Url = resultPage.nextPage.AbsoluteUri;
            } while (restRequest.Url != null);
        }

        public Tuple<string, List<T>> GetListUsingDetag<T>(string endpointUrl, string detagValue)
        {
            var restRequest = new RestRequest
            {
                Url = endpointUrl,
                Method = HttpMethod.Get,
                Detag = detagValue
            };
            var response = _restClient.Execute(restRequest);
            detagValue = response.Headers.Get("x-deere-signature");

            if (response.StatusCode == HttpStatusCode.NotModified)
                return Tuple.Create(detagValue, new List<T>());
            return Tuple.Create(detagValue, response.GetResponseAsList<T>());
        }
    }
}
