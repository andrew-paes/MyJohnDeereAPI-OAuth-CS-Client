using SampleApp.Sources.democlient.rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Sources.democlient
{
    abstract class ApiCredentials
    {
        public static OAuthClient CLIENT = new OAuthClient("your app id from developer.deere.com", "your app secret from developer.deere.com");
        public static OAuthToken TOKEN = new OAuthToken("token generated after running the oauth worflow code", "secret generated after running the oauth workflow code");
    }
}
