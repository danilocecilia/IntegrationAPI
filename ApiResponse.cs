using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public object Value { get; set; }
        public string Message { get; set; }
    }
}
