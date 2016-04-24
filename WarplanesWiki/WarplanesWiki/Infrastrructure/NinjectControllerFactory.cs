using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Moq;
using Ninject;
using WarplainsDomain.Abstract;
using WarplainsDomain.Concrete;
using WarplainsDomain.Entities;

namespace WarplanesWiki.Infrastrructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel Kernel { get;}
        public NinjectControllerFactory()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null? null: (IController)Kernel.Get(controllerType);
        }
        private void AddBindings()
        {
            Kernel.Bind<IWarplaneRepository>().To<EFWarplaneRepository>();
            
        }
    }
}