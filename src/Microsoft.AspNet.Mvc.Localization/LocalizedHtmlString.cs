// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc.Rendering;

namespace Microsoft.AspNet.Mvc.Localization
{
    public class LocalizedHtmlString : HtmlString
    {
        public LocalizedHtmlString(string key, string value)
            : this(key, value, resourceNotFound: false)
        {

        }

        public LocalizedHtmlString(string key, string value, bool resourceNotFound)
            : base(value)
        {
            Key = key;
        }

        public string Key { get; private set; }

        public string Value => ToString();

        public bool ResourceNotFound { get; private set; }
    }
}