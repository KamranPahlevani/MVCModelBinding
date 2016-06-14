using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure.CustomModelBinder
{
    public class PersonModelBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = (Person)bindingContext.Model ?? (Person)DependencyResolver.Current.GetService(typeof(Person));

            bool hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
            string searchPrefix = hasPrefix ? bindingContext.ModelName + "." : "";

            model.PersonID = int.Parse(this.GetValue(bindingContext, searchPrefix, "PersonID") ?? "0");
            model.FirstName = this.GetValue(bindingContext, searchPrefix, "FirstName");
            model.LastName = this.GetValue(bindingContext, searchPrefix, "LastName");
            model.BirthDate = DateTime.Parse(this.GetValue(bindingContext, searchPrefix, "BirthDate"));
            model.IsApproved = this.GetCheckedValue(bindingContext, searchPrefix, "IsApproved");
            model.Role = (Role)Enum.Parse(typeof(Role), this.GetValue(bindingContext, searchPrefix, "Role"));

            return model;
        }

        private string GetValue(ModelBindingContext context, string prefix, string key)
        {
            ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
            return vpr != null ? vpr.AttemptedValue : null;
        }

        private bool GetCheckedValue(ModelBindingContext context, string prefix, string key)
        {
            bool result = false;
            ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
            if (vpr != null)
                result = (bool)vpr.ConvertTo(typeof(bool));
            return result;
        }
    }
}