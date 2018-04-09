using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompWithBoo.Models
{
    public class jqDataTableParameter
    {
        public string sEcho { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }
}