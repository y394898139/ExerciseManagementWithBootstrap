using CompWithBoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompWithBoo.Controllers
{
    public class Page
    {
        private int currentPage { get; set; }
        //The number of pages per page
        private int pageSize { get; set; }
        //Paged data
        private List<Exercise> list { get; set; }
        //The total number of data
        private int size { get; set; }
        //The total number of pages
        private int totalPage { get; set; }

        public Page()
        {
        }
        public Page(int currentPage, int pageSize)
        {
            this.currentPage = currentPage;
            this.pageSize = pageSize;
        }
    }
}