using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Infrastructure.CustomValueProvider
{
    public class CustomTimeValueProvider:IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("currentTime", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            return this.ContainsPrefix(key) ? new ValueProviderResult(DateTime.Now, null, CultureInfo.InvariantCulture) : null;
        }
    }
}