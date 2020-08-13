using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo1.Models.Home
{
    public class BullitinModel
    {
        public List<string> formColumns { get; set; }
        public string MESSAGE { get; set; }       
    }

    
    /// <summary>
    /// List of MenuModel
    /// </summary>
    public class MenuModel
    {
        public string Text {get;set;}
        public string URL {get; set; }
        public string ChildText { get; set; }
        public string FatherText { get; set; }
    }

}