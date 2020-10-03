using ECommerceApp.BLL.Helpers.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ECommerceApp.BLL.Models
{
    public class ProductVM
    {
        public string Id { get; set; }

        [Required, Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Required, Display(Name = "Barkod")]
        public string Barcode { get; set; }

        [Required, Display(Name = "Fiyat")]
        public decimal UnitPrice { get; set; }

        [Required, Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required, Display(Name = "Adet")]
        public int UnitsInStock { get; set; }

        [Required, Display(Name = "Ürün Resimleri")]
        [File(FileTypes = new string[] { "image/png", "image/jpeg", "image/jpg" })]
        public virtual List<HttpPostedFileBase> Images { get; set; }

        public List<string> DisplayImages { get; set; }
    }
}
