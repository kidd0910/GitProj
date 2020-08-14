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
        public string LEVEL { get; set; }
        public string TEXT {get;set;}
        public string URL {get; set; }
        public List<MenuModel> CHILD { get; set; }
        public string FATHER { get; set; }

        public string DIR_ID { get; set; }
        public string DIR_NM { get; set; }
        public string DIR_SORT { get; set; }
        public string SUB_DIR_ID { get; set; }
        public string SUB_DIR_NM { get; set; }
        public string SUB_DIR_SORT { get; set; }
        public string PROG_CD { get; set; }
        public string PROG_NM { get; set; }
        public string PROG_SORT { get; set; }
    }

}