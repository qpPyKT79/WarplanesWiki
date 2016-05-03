using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarplanesWiki.Models;

namespace WarplanesWiki.Binders
{
    public class ComparisonModelBinder: IModelBinder
    {
        private const string sessionKey = "Comparison";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var comparison = (Comparison)controllerContext.HttpContext.Session[sessionKey];
            if (comparison == null)
            {
                comparison = new Comparison();
                controllerContext.HttpContext.Session[sessionKey] = comparison;
            }
            return comparison;
        }
    }
}