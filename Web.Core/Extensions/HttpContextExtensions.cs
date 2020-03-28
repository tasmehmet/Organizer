﻿﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Web.Core.Extensions
{
    public static class HttpContextExtensions
    {

        public static object GetItemValue(this IDictionary<object, object> dictionary, object key)
        {
            dictionary.TryGetValue(key, out object value);
            return value;
        }


        public static T GetItemValue<T>(this IDictionary<object, object> dictionary, object key)
        {
            var value = GetItemValue(dictionary, key);
            return value == null ? default(T) : (T)value;
        }
    }
}
