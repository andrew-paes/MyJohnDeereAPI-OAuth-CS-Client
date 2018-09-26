using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
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
				var response = ExecuteWithRetry(restRequest);
                var resultPage = response.GetResponsePage<T>();

				// If the page is null, then we got an empty response. 
				// Maybe your user can't access any organizations, or maybe you requested data and there wasn't any.
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
			var response = ExecuteWithRetry(restRequest);
            detagValue = response.Headers.Get("x-deere-signature");

            if (response.StatusCode == HttpStatusCode.NotModified)
                return Tuple.Create(detagValue, new List<T>());
            return Tuple.Create(detagValue, response.GetResponseAsList<T>());
        }

		private HttpWebResponse ExecuteWithRetry(RestRequest request) {
			var maxRetries = 4;
			var numberOfAttempts = 0;
			while (numberOfAttempts < maxRetries) 
			{
				var response = _restClient.Execute(request);
				// See https://developer.deere.com/#!documentation&doc=myjohndeere%2F429.htm
				// Note System.Net.HttpStatusCode does not include 429, but C# enum handling allows non-specified values
				if (response.StatusCode == (HttpStatusCode)429) {
					var secondsToWait = Int32.Parse (response.Headers.Get ("Retry-After"));
					Thread.Sleep (1000 * secondsToWait);
				} else if (response.StatusCode == HttpStatusCode.ServiceUnavailable || response.StatusCode == HttpStatusCode.InternalServerError) 
				{
					// Sorry. Something probably went wrong on our end. 
					// Exponential backoff raises the odds that waiting a few milliseconds results in a successful retry
					Thread.Sleep(Math.Pow (10, numberOfAttempts + 1));
				} else 
				{
					return response;
				}
				numberOfAttempts++;
			}
		}
    }
}
