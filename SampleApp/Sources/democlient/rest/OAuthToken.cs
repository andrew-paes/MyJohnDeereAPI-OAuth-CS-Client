using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Sources.democlient.rest
{
    class OAuthToken
    {
        public String token;
        public String secret;

    public OAuthToken(String token, String secret) {
        this.token = token;
        this.secret = secret;
    }
    }
}
