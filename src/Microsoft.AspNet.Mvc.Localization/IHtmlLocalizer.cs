// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Globalization;
using Microsoft.Framework.Localization;

namespace Microsoft.AspNet.Mvc.Localization
{
    public interface IHtmlLocalizer : IStringLocalizer
    {
        new IHtmlLocalizer WithCulture(CultureInfo culture);

        LocalizedHtmlString Html(string key);

        LocalizedHtmlString Html(string key, params object[] arguments);
    }
}