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

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Barcode { get; set; }

        [Required, Display(Name = "Unit Price"), Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        public decimal UnitPrice { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, Display(Name = "Units In Stock"), Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
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
