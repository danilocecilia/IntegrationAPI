using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace IntegrationAPI
{
    public static class Utilities
    {
        public static string GetPostForm(string url, NameValueCollection values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", url);

            var allKeys = values.AllKeys;
            foreach (var key in allKeys)
            {
                sb.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", key, values[key]);
            }

            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }
    }
}
