using ModelBinding.Infrastructure.CustomValueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure.Factories
{
    public class CustomTimeValueProviderFactory:ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CustomTimeValueProvider();
        }
    }
}