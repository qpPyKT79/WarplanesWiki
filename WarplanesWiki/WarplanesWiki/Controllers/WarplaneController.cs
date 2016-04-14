using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplainsDomain.Abstract;

namespace WarplanesWiki.Controllers
{
    public class WarplaneController : Controller
    {

        private IWarplaneRepository repository;

        public WarplaneController(IWarplaneRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Warplanes);
        }

    }
}