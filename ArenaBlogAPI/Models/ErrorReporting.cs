using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaBlogAPI.Models
{
    public class ErrorReporting
    {
        public bool Error { get; set; }
        public dynamic ErrorDetail { get; set; }
        public dynamic Results { get; set; }
    }
}