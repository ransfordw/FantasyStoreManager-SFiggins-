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
    [Authorize]
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var service = CreateStoreService();
            var model = service.GetStores();
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
        public ActionResult Create(StoreCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateStoreService();
            if (service.CreateStore(model))
            {
                TempData["SaveResult"] = "Your store was built.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Store could not be built.");
            return View(model);
        }

        //GET:
        public ActionResult Details(int id)
        {
            var svc = CreateStoreService();
            var model = svc.GetStoreById(id);
            return View(model);
        }

        //GET:
        public ActionResult Edit(int id)
        {
            var service = CreateStoreService();
            var detail = service.GetStoreById(id);
            var model = new StoreEdit
            {
                StoreId = detail.StoreId,
                Name = detail.Name,
                Location = detail.Location,
                TypeOfStore = detail.TypeOfStore
            };
            return View(model);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StoreEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.StoreId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateStoreService();
            if (service.UpdateStore(model))
            {
                TempData["SaveResult"] = "Your store was refurbished.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your store could not be refurbished.");
            return View();
        }

        //GET:
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStoreService();
            var model = svc.GetStoreById(id);
            return View(model);
        }

        //DELETE:
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStoreService();
            service.DeleteStore(id);
            TempData["SaveResult"] = "Your store was destroyed by murderhobos.";
            return RedirectToAction("Index");
        }

        private StoreService CreateStoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StoreService(userId);
            return service;
        }
    }
}