using System;
using System.Collections.Generic;
using System.Text;

namespace Rdcs.Authorization
{
    public class AuthorizationToken
    {
        public bool authenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }

        public AuthorizationToken(){ }

        public AuthorizationToken(DateTime created, DateTime expiration)
        {
            this.authenticated = true;
            this.created = created.ToString("yyyy-MM-dd HH:mm:ss");
            this.expiration = expiration.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public AuthorizationToken(string message)
        {
            this.authenticated = false;
            this.message = message;
        }
    }
}
