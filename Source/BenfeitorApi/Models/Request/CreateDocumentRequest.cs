using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenfeitorApi.Models.Request
{
    public class CreateDocumentRequest
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}