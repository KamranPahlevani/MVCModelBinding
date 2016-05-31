using ModelBinding.Infrastructure.CustomModelBinder;
using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure.CustomModelBinderProvider
{
    public class CustomModelBinderProvider:IModelBinderProvider
    {

        public IModelBinder GetBinder(Type modelType)
        {
            return modelType == typeof(Person) ? new PersonModelBinder() : null;
        }
    }
}