namespace SampleApp.Sources.democlient
{
    public class ApiCredentials
    {
        public string ClientKey { get; set; }
        public string ClientSecret { get; set; }
        public string TokenKey { get; set; }
        public string TokenSecret { get; set; }

        public ApiCredentials()
        {
            ClientKey = "Your application's 'App ID' from developer.deere.com";
            ClientSecret = "Your application's 'Shared Secret' from developer.deere.com";

            TokenKey = "This is generated from the oAuth workflow; see OAuthWorkFlow.GetRequestToken()";
            TokenSecret = "This is generated from the oAuth workflow; see OAuthWorkFlow.GetRequestToken()";
        }
    }
}
