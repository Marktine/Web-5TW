using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5TW.Models
{
    public class DetailCollectionViewModel
    {
        public string CollectionName { get; set; }
        public List<Product> Products { get; set; }
    }
}