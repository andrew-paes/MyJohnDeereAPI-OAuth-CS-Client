using System;
using System.Net;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using DevDefined.OAuth.Storage.Basic;

namespace SampleApp.Sources.democlient.rest
{
    public class RestClient
    {
        private readonly ApiCredentials _credentials;

        public RestClient(ApiCredentials credentials)
        {
            _credentials = credentials;
        }
        
        public WebResponse Execute(RestRequest request)
        {
            var signedRequest = CreateSignedOauthRequest(request);
            var httpWebRequest = signedRequest.ToWebRequest();

            var httpWebResponse = httpWebRequest.GetResponse();
            return httpWebResponse;
        }

        private IConsumerRequest CreateSignedOauthRequest(RestRequest request)
        {
            var oAuthContext = MapRequestToOauthContext(request);
            var oAuthConsumerContext = new OAuthConsumerContext()
            {
                ConsumerKey = _credentials.ClientKey,
                ConsumerSecret = _credentials.ClientSecret,
                SignatureMethod = SignatureMethod.HmacSha1,
                UseHeaderForOAuthParameters = true
            };
            var accessToken = new AccessToken
            {
                ConsumerKey = _credentials.ClientKey,
                Token = _credentials.TokenKey,
                TokenSecret = _credentials.TokenSecret
            };

            var consumerRequest = new ConsumerRequest(oAuthContext, oAuthConsumerContext, accessToken);
            return consumerRequest.WithAcceptHeader(request.Accept)
                .WithRawContentType(request.ContentType).SignWithToken(accessToken);
        }

        private static OAuthContext MapRequestToOauthContext(RestRequest request)
        {
            var oAuthContext = new OAuthContext
            {
                UseAuthorizationHeader = true,
                RawUri = new Uri(request.Url),
                RequestMethod = request.Method.Method,
                Headers = request.Headers.ToNameValueCollection()
            };
            if (request.BinaryPayload != null)
            {
                oAuthContext.RawContent = request.BinaryPayload;
                oAuthContext.RawContentType = request.Headers["Content-Type"];
            }

            return oAuthContext;
        }
    }
}