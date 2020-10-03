using ECommerceApp.BLL.Abstract;
using ECommerceApp.BLL.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerceApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IImagesManager _imagesManager;
        public ProductController(IProductManager productManager, IImagesManager imagesManager)
        {
            _productManager = productManager;
            _imagesManager = imagesManager;
        }

        public ActionResult Index()
        {
            return View(_productManager.GetNameList());
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_productManager.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id, DisplayImages")]ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _productManager.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "DisplayImages")]ProductVM model)
        {
            if (ModelState.IsValid)
            {
                _productManager.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }

            if (_productManager.Delete(id))
                return Json(new { Result = "OK" });

            return Json(new { Result = "ERROR", Message = "Silinemedi" });
        }

        [HttpPost]
        public JsonResult DeleteFile(Guid id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }


            if (_imagesManager.Delete(id))
                return Json(new { Result = "OK" });

            return Json(new { Result = "ERROR", Message = "Silinemedi" });
        }
    }
}