using FantasyStoreManager.Data;
using FantasyStoreManager.Models;
using FantasyStoreManager.Services;
using FantasyStoreManager.WebMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FantasyStoreManager.WebMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            var service = CreateInventoryService();
            var model = service.GetStores();

            return View(model);
        }

        //GET:
        public ActionResult Create(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = CreateInventoryService();
            var service = CreateStoreService();
            var storeDetail = service.GetStoreById(id);
            var viewModel = new CreateInventoryPassStoreId
            {
                StoreId = storeDetail.StoreId,
                Name = storeDetail.Name
            };
            ViewBag.StoreId = viewModel;
            var productList = new SelectList(svc.Products(), "ProductId", "Name");
            ViewBag.ProductId = productList;
            ViewBag.StoreInventory = new SelectList(svc.GetStoreInventories(id), "StoreInventory", "Products");
            ViewBag.InventoryCount = new SelectList(svc.GetStoreInventories(id), "InventoryCount", "Count");

            var model = svc.GetInventoryCreateModel(id);
            if (model.InventoryCount != 0)
                return View(model);
            else
                return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, InventoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateInventoryService();
            if (service.CreateInventory(id, model))
            {
                TempData["SaveResult"] = "Products were added to your inventory.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be added.");
            ViewBag.ProductId = new SelectList(service.Products(), "ProductId", "Name");

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ListStoreInventoryInCreate(int id)
        {
            var svc = CreateInventoryService();
            IEnumerable<InventoryListItem> model = svc.GetStoreInventories(id);
            return View(model);
        }

        public ActionResult InventoryIndex(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetStoreInventories(id);

            return View(model);
        }

        public ActionResult InventoryDetails(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);

            return RedirectToAction("Details", "Product");
        }

        //GET:
        public ActionResult Edit(int id)
        {
            var service = CreateInventoryService();
            var detail = service.GetInventoryById(id);
            var model = new InventoryEdit
            {
                InventoryId = detail.InventoryId,
                ProductId = detail.ProductId,
                Quantity = detail.Quantity
            };
            return View(model);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.InventoryId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateInventoryService();
            if (service.UpdateInventory(model))
            {
                TempData["SaveResult"] = $"Your inventory was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"Your inventory could not be updated.");
            return View();
        }

        //GET:
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);
            return View(model);
        }

        //DELETE:
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInventoryService();
            service.DeleteInventory(id);
            TempData["SaveResult"] = $"You ran out of inventory.";
            return RedirectToAction("Index");
        }

        private InventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            return service;
        }

        private StoreService CreateStoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StoreService(userId);
            return service;
        }

        private string PrivateEnumHelper(ProductType productType)
        {
            var item = EnumHelper<ProductType>.GetDisplayValue(productType);

            return item;
        }
    }
}