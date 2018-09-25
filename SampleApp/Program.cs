using SampleApp.Sources.democlient;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please paste your App Id and Shared Secret from your application profile on https://developer.deere.com
            string clientKey = "Your application's 'App ID' from developer.deere.com";
            string clientSecret = "Your application's 'Shared Secret' from developer.deere.com";

            var oauthWorkflowExample = new OAuthWorkFlow();
            var apiCredentials = oauthWorkflowExample.Authenticate(clientKey, clientSecret);


//            /* For Oauth tokens please un-comment line 1 to line 4 also please plugin your App Id and Secret from https://developer.deere.com app profile in ApiCredentials.cs CLIENT constructor
//             * Once access tokens are generated please plug te valus into  ApiCredentials.cs OAuthToken constructor
//             * 
//             * To run the file download example, please comment out Line 1 to Line 4 and un-comment Line 5
//             * To run the file download example, please comment out Line 1 to Line 5 and un-comment Line 6
//             */
//
//            of.retrieveApiCatalogToEstablishOAuthProviderDetails();  //Line 1
//            of.getRequestToken();                                    //Line 2
//            of.authorizeRequestToken();                              //Line 3
//            of.exchangeRequestTokenForAccessToken();                 //Line 4
//
//            //Download dn = new Download();                          //Line 5
//            //dn.retrieveApiCatalog();
//
//            //Upload up = new Upload();                              //Line 6
//            //up.retrieveApiCatalog();                               //Line 7

        }
       
    }
}
