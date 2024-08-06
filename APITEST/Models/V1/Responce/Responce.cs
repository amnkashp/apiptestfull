using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace APITEST.Models.V1.Responce
{
    public class Responce
    {
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public string Result { get; set; }
    }

    public class ResponceList
    {
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public JObject Result { get; set; }
    }
}