using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo1.Models.Default
{
    public class PageModel
    {
        public List<string> formColumns { get; set; }
        public string MESSAGE { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string ID { get; set; }
        public string PW { get; set; }
    }

    public class QueryModel
    {
        public string ID { get; set; }
        public string PW { get; set; }
        public string MESSAGE { get; set; }
        public string ERROR_MESSAGE { get; set; }
    }
}