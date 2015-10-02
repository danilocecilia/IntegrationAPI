using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI
{
    public static class Constants
    {
        // Url for MVCForum
        public const string ForumUrl = "http://localhost:54598/";
        // Url for main website
        public const string WebsiteUrl = "http://localhost:53161";
        // Use this password in headers in all requests between the two sites to prevent abuse from people who finds the url.
        // Alternatively, you could "log in" and do the requests with a login-cookie instead and user membership permissions.
        // I just took the easy way.
        public const string Password = "SecretPassword";
    }
}
