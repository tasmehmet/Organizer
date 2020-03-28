﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Web.Core.Extensions
{
    public static class CookieExtensions
    {
        public static string GetCookieValue(this IRequestCookieCollection cookieCollection, string key)
        {
            cookieCollection.TryGetValue(key, out string value);
            return value ?? string.Empty;
        }

        public static void SetCookie(this IResponseCookies cookieCollection, string key,string value, DateTimeOffset expires)
        {
            cookieCollection.Append(key, value, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = expires
            });
        }
    }
}
