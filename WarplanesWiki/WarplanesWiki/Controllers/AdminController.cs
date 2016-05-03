using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplainsDomain.Abstract;
using WarplainsDomain.Entities;

namespace WarplanesWiki.Controllers
{
    [Authorize(Users = "el_razor@mail.ru")]
    public class AdminController : Controller
    {
        private IWarplaneRepository repo;
        public AdminController(IWarplaneRepository productRepository)
        {
            this.repo = productRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repo.Warplanes);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.Warplanes.FirstOrDefault(x=>x.WarplaneID==id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Warplane plane)
        {
            try
            {
                // TODO: Add insert logic here
                repo.SavePlane(plane);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.Warplanes.FirstOrDefault(x => x.WarplaneID == id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Warplane plane)
        {
            try
            {
                // TODO: Add update logic here
                repo.SavePlane(plane);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.Warplanes.FirstOrDefault(x => x.WarplaneID == id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Warplane plane)
        {
            try
            {
                // TODO: Add delete logic here
                repo.RemovePlane(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}
