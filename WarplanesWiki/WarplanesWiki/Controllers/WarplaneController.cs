using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplainsDomain.Abstract;
using WarplanesWiki.Models;

namespace WarplanesWiki.Controllers
{
    public class WarplaneController : Controller
    {

        private IWarplaneRepository repository;
        public int PageSize = 1;

        public WarplaneController(IWarplaneRepository productRepository)
        {
            this.repository = productRepository;
        }

        //public ViewResult List()
        //{
        //    return View(repository.Warplanes);
        //}
        public ViewResult List(int category, string country, int page = 1)
        {
            var model = new WarplanesListViewModel
            {
                Warplanes = repository.Warplanes
                    .Where(p => p.Category == (WarplainsDomain.Entities.WarplaneCategoty)category)
                    .Where(p => p.Country == country || country == "")
                    .OrderBy(p => p.WarplaneID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Warplanes.Count()
                },
                CurrentPlaneCategory = category
            };
            return View(model);
        }
    }
}