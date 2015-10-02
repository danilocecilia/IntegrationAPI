using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace IntegrationAPI.Website
{
    public class Membership
    {
        public ApiResponse ChangePassword(string userId, string password)
        {
            ApiResponse response;

            var url = Constants.WebsiteUrl + "ChangePassword";
            var data = new NameValueCollection();
            data["userId"] = userId;
            data["password"] = password;

            using (var wc = new ApiWebClient(data, url))
            {
                response = wc.GetResponse();
            }
            return response;
        }
    }
}
