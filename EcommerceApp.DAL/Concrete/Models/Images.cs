using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.DAL.Concrete.Models
{
    public class Images : BaseEntity
    {       
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string FileType { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}
