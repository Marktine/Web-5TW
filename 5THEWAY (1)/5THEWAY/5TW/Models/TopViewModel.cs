using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5TW.Models
{
    public class TopViewModel
    {
        public List<string> AllShirtsType { get; set; }
        public List<Product> lstShirts { get; set; }

        public string Title { get; set; }

    }
}