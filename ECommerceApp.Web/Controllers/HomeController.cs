using ECommerceApp.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;
        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public ActionResult Index()
        {
            return View(_productManager.GetList());
        }
    }
}