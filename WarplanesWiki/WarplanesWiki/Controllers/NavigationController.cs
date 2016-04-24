using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplainsDomain.Abstract;

namespace WarplanesWiki.Models
{
    public class NavigationController : Controller
    {
        private IWarplaneRepository repository;
        public NavigationController(IWarplaneRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            var categories = repository.Warplanes
            .Select(x => x.Category)
            .Distinct();
            return PartialView(categories);
        }
    }
}