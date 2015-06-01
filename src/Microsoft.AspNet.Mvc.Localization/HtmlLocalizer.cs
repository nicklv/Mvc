// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.Localization;
using Microsoft.Framework.WebEncoders;

namespace Microsoft.AspNet.Mvc.Localization
{
    public class HtmlLocalizer : IHtmlLocalizer
    {
        private readonly IStringLocalizer _localizer;
        private readonly IHtmlEncoder _encoder;

        public HtmlLocalizer(IStringLocalizer localizer, IHtmlEncoder encoder)
        {
            _localizer = localizer;
            _encoder = encoder;
        }

        public virtual IHtmlLocalizer WithCulture(CultureInfo culture) 
            => new HtmlLocalizer(_localizer.WithCulture(culture), _encoder);

        IStringLocalizer IStringLocalizer.WithCulture(CultureInfo culture) => WithCulture(culture);

        public virtual LocalizedString this[string key] => _localizer[key];

        public virtual LocalizedString this[string key, params object[] arguments] => _localizer[key, arguments];

        public virtual LocalizedString GetString(string key) => _localizer.GetString(key);

        public virtual LocalizedString GetString(string key, params object[] arguments) 
            => _localizer.GetString(key, arguments);

        public virtual LocalizedHtmlString Html(string key) => ToHtmlString(_localizer.GetString(key));

        public virtual LocalizedHtmlString Html(string key, params object[] arguments)
        {
            return ToHtmlString(_localizer.GetString(key, EncodeArguments(arguments)));
        }

        protected LocalizedHtmlString ToHtmlString(LocalizedString result)
        {
            return new LocalizedHtmlString(result.Name, result.Value, result.ResourceNotFound);
        }

        protected object[] EncodeArguments(object[] arguments)
        {
            object[] encodedArguments = new object[arguments.Length];
            for (var index = 0; index != arguments.Length; ++index)
            {
                var argument = arguments[index];
                if (argument.GetType().GetTypeInfo().IsPrimitive ||
                    argument is HtmlString ||
                    argument is DateTime ||
                    argument is DateTimeOffset)
                {
                    encodedArguments[index] = argument;
                }
                else
                {
                    encodedArguments[index] = _encoder.HtmlEncode(argument.ToString());
                }
            }
            return encodedArguments;
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
            => _localizer.GetAllStrings(includeAncestorCultures);
    }
}