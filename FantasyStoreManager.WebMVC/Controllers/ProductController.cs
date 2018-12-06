using FantasyStoreManager.Data;
using FantasyStoreManager.Models;
using FantasyStoreManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantasyStoreManager.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var service = CreateProductService();
            var model = service.GetProducts();

            foreach(var item  in model)
            {
                item.TypeOfProductString = PrivateEnumHelper(item.TypeOfProduct);
            }

            return View(model);
        }

        //GET:
        public ActionResult Create()
        {
            return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateProductService();
            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was crafted.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Product could not be crafted.");
            return View(model);
        }

        //GET:
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);
            model.TypeOfProductString = PrivateEnumHelper(model.TypeOfProduct);

            return View(model);
        }

        //GET:
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model = new ProductEdit
            {
                ProductId = detail.ProductId,
                Name = detail.Name,
                Description = detail.Description,
                TypeOfProduct = detail.TypeOfProduct,
                Price = detail.Price,
                IsMagical = detail.IsMagical
            };
            return View(model);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateProductService();
            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = $"Your {model.Name} was repaired.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"Your {model.Name} could not be repaired.");
            return View();
        }

        //GET:
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);
            model.TypeOfProductString = PrivateEnumHelper(model.TypeOfProduct);
            return View(model);
        }

        //DELETE:
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();
            service.DeleteProduct(id);
            TempData["SaveResult"] = $"Your item was stolen by brigands.";
            return RedirectToAction("Index");
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }

        private string PrivateEnumHelper(ProductType productType)
        {
            var item = EnumHelper<ProductType>.GetDisplayValue(productType);

            return item;
        }
    }
}