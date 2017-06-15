using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5TW.Models
{
    public class BottomViewModel
    {
        public List<string> AllBottomTypes { get; set; }
        public List<Product> lsBottomProducts { get; set; }

        public string Title { get; set; }
    }
}