using EcommerceApp.DAL.Concrete.Models;
using ECommerceApp.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ECommerceApp.Web.App_Start.IdentityConfig;

namespace ECommerceApp.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }                
    }
}