using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5TW.Models
{
    public class AccessoriesViewModel
    {
        public List<string> AllAccessoriesTypes { get; set; }
        public List<Product> lsAccessories { get; set; }

        public string Title { get; set; }
    }
}