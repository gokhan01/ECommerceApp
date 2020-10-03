using ECommerceApp.BLL.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ECommerceApp.BLL.Models
{
    public class ProductVM
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Barcode { get; set; }

        [Required, Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [File(FileTypes = new string[] { "image/png", "image/jpeg", "image/jpg" })]
        public virtual List<HttpPostedFileBase> Images { get; set; }

        public List<DisplayImageVM> DisplayImages { get; set; } = new List<DisplayImageVM>();
    }

    public class DisplayImageVM
    {
        public Guid Id { get; set; }
        public string FileContent { get; set; }
    }
}
