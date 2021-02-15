using System;
using System.Collections.Generic;
using System.Linq;

namespace Wedding.WebApp
{
    public static class GooglePhotoKeyValuePair
    {
        private static readonly string[] Separator =
        {
            "="
        };

        public static KeyValuePair<string, string> Create(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(url));
            }

            var baseUrl = url.Split(Separator, 2, StringSplitOptions.None).First();
            
            return KeyValuePair.Create(baseUrl, url);
        }
    }
}