using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplainsDomain.Abstract;

namespace WarplanesWiki.Models
{
    public class ComparingController : Controller
    {
        private IWarplaneRepository repository;

        public ComparingController(IWarplaneRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddToCompare(Comparison comparison, int warplaneId, string returnUrl)
        {
            var plane = repository.Warplanes.FirstOrDefault(p => p.WarplaneID == warplaneId);
            if (plane != null)
            {
                comparison.AddPlane(plane);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCompar(Comparison comparison, int warplaneId, string returnUrl)
        {
            var plane = repository.Warplanes.FirstOrDefault(p => p.WarplaneID == warplaneId);
            if (plane != null)
            {
                comparison.RemovePlane(plane);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Index(Comparison comparison, string returnUrl)
        {
            return View(new ComparisonIndexViewModel
            {
                CompareCollection = comparison,
                ReturnUrl = returnUrl
            });
        }
    }
}