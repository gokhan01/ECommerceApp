using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Web.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}