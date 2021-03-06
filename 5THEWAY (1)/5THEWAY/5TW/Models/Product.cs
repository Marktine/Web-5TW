//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _5TW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ProID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int CloType { get; set; }
        public int CollectionID { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    
        public virtual ClothesType ClothesType { get; set; }
        public virtual Collection Collection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductStatu ProductStatu { get; set; }
    }
}
