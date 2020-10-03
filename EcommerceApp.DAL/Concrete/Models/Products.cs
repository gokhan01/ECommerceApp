using System.Collections.Generic;

namespace EcommerceApp.DAL.Concrete.Models
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }

        public virtual List<Images> Images { get; set; }
    }
}
