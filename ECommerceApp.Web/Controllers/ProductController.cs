using ECommerceApp.BLL.Abstract;
using ECommerceApp.BLL.Models;
using System.Net;
using System.Web.Mvc;

namespace ECommerceApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public ActionResult Index()
        {
            return View(_productManager.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _productManager.Create(model);
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = _productManager.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _productManager.Edit(model);
            }

            return View();
        }
    }
}