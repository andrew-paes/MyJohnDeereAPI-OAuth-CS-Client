﻿using System;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace SampleApp.Sources.democlient
{
    // For additional, non Deere specific examples of using the DevDefined.OAuth libraries, see:
    // https://github.com/bittercoder/DevDefined.OAuth-Examples
    public class OAuthWorkFlow
    {
        private const string AuthenticationUrl = "https://sandboxapi.deere.com/platform/oauth/request_token";
        private const string UserAuthorizeUrl = "https://my.deere.com/consentToUseOfData?oauth_token={0}";
        private const string AccessTokenUrl = "https://sandboxapi.deere.com/platform/oauth/access_token";

        public ApiCredentials Authenticate(string applicationKey, string applicationSecret)
        {
            // Step 1: Get an oAuth request token using your application's key and secret
            var requestToken = GetRequestToken(applicationKey, applicationSecret);
            
            // Step 2: Get explicit consent from the user to access their data
            var verificationCode = GetUserAuthorization(requestToken.Token);
            
            // Step 3: Exchange the oAuth request token and user verification code for an oAuth access token
            return ExchangeRequestTokenForAccessToken(applicationKey, applicationSecret, requestToken, verificationCode);
        }

        public void AuthenticateWithCallback(string applicationKey, string applicationSecret, string callbackUrl)
        {
            // This alternate version is useful if you have a webapp and can specify a callback URL
            // It eliminates the need to copy/paste a verification code.
            var oAuthSession = CreateOAuthSession(applicationKey, applicationSecret);
            oAuthSession.RequestTokenUri = new Uri(AuthenticationUrl);
            oAuthSession.CallbackUri = new Uri(callbackUrl);
            var requestToken = oAuthSession.GetRequestToken();

            var userAuthorizeUrl = oAuthSession.GetUserAuthorizationUrlForToken(requestToken, callbackUrl);
            // Now, userAuthorizeUrl contains a website address. Send the user to that website address to sign in 
            // and authorize your application. 
            //
            // On your server, there needs to be a service at uri {callbackUrl} that can accept the callback once
            // the user authenticates. For an example of that, check out the DevDefined.OAuth project:
            // https://github.com/bittercoder/DevDefined.OAuth/blob/master/src/DevDefined.OAuth.Wcf/OAuthInterceptor.cs
        }

        private ApiCredentials ExchangeRequestTokenForAccessToken(string applicationKey, string applicationSecret, 
                                                                  IToken requestToken, string verificationCode)
        {
            var oAuthSession = CreateOAuthSession(applicationKey, applicationSecret);
            oAuthSession.AccessTokenUri = new Uri(AccessTokenUrl);
            var accessToken = oAuthSession.ExchangeRequestTokenForAccessToken(requestToken, verificationCode);
            
            return new ApiCredentials
            {
                ClientKey = applicationKey,
                ClientSecret = applicationSecret,
                TokenKey = accessToken.Token,
                TokenSecret = accessToken.TokenSecret
            };
        }

        private IToken GetRequestToken(string applicationKey, string applicationSecret)
        {
            var oAuthSession = CreateOAuthSession(applicationKey, applicationSecret);
            oAuthSession.RequestTokenUri = new Uri(AuthenticationUrl);
            var requestToken = oAuthSession.GetRequestToken();

            return requestToken;
        }

        private string GetUserAuthorization(string requestToken)
        {
            var userAuthorizationUrl = string.Format(UserAuthorizeUrl, requestToken);
            
            // This opens the default browser to https://my.deere.com/consentToUseOfData?oauth_token={token}
            // If you have a webapp, just have the user navigate to this url.
            //  
            // Sign in to the MyJohnDeere login screen and grant your application access to your data.
            // Once you are done, the screen should show a "verifier code". Enter the code into the application terminal.
            System.Diagnostics.Process.Start(userAuthorizationUrl);

            Console.WriteLine("Please enter the verifier code from your browser:");
            var verificationCode = Console.ReadLine();

            return verificationCode;
        }

        private OAuthSession CreateOAuthSession(string applicationKey, string applicationSecret)
        {
            var oAuthContext = new OAuthConsumerContext
            {
                ConsumerKey = applicationKey,
                ConsumerSecret = applicationSecret,
                SignatureMethod = SignatureMethod.HmacSha1
            };
            var oAuthSession = new OAuthSession(oAuthContext);
            return oAuthSession;
        }
    }
}
