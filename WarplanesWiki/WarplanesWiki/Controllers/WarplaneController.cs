﻿using System;
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
        public int PageSize = 2;

        public WarplaneController(IWarplaneRepository productRepository)
        {
            this.repository = productRepository;
        }

        //public ViewResult List()
        //{
        //    return View(repository.Warplanes);
        //}
        public ViewResult List(int category = 0, string country = (string)null, int page = 1)
        {
            var warplanes = repository.Warplanes
                .Where(p => p.Category == (WarplainsDomain.Entities.WarplaneCategoty) category || category == 0)
                .Where(p => p.Country == country || country == (string) null)
                .OrderBy(p => p.WarplaneID);
            var model = new WarplanesListViewModel
            {
                Warplanes = warplanes
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = warplanes.Count()
                },
                CurrentPlaneCategory = category
            };
            return View(model);
        }
    }
}