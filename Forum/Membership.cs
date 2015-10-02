using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntegrationAPI.Forum
{
    public class Membership
    {
        public ApiResponse CreateUser(string username, string password, string email, bool isApproved, DateTime createdAt, string botHavenId)
        {
            ApiResponse response;

            var url = Constants.ForumUrl + "CreateUser";
            var data = new NameValueCollection();
            data["UserName"] = username;
            data["Email"] = email;
            data["Password"] = password;
            data["IsApproved"] = isApproved.ToString().ToLower();
            data["botHavenId"] = botHavenId;
            data["createdAt"] = createdAt.Ticks.ToString();

            using (var wc = new ApiWebClient(data, url))
            {
                response = wc.GetResponse();
            }
            if (response.Success)
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        data = new NameValueCollection();
                        data["Id"] = (string)response.Value;
                        wc.UploadValues("http://forums.bothaven.com/Badge/Time", data);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            return response;
        }

        public ApiResponse ApproveUser(string userId)
        {
            ApiResponse response;

            var url = Constants.ForumUrl + "ApproveUser";
            var data = new NameValueCollection();
            data["userId"] = userId;

            using (var wc = new ApiWebClient(data, url))
            {
                response = wc.GetResponse();
            }
            return response;
        }

        public ApiResponse ChangePassword(string userId, string password)
        {
            ApiResponse response;

            var url = Constants.ForumUrl + "ChangePassword";
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
