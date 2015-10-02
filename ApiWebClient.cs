using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntegrationAPI
{
    public class ApiWebClient : WebClient
    {
        private NameValueCollection _values;
        private string _url;
        public ApiWebClient(NameValueCollection values, string url)
        {
            _values = values;
            _url = url;
            Headers.Add("AppPW", Constants.Password);
        }

        public ApiResponse GetResponse()
        {
            var response = UploadValues(_url, "POST", _values);
            var responseString = Encoding.Default.GetString(response);
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);
            return apiResponse;
        }
    }
}
