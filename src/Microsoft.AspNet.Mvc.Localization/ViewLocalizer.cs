// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.Localization;
using Microsoft.Framework.Runtime;

namespace Microsoft.AspNet.Mvc.Localization
{
    /// <summary>
    /// An <see cref="IViewLocalizer"/> that provides localized strings for views.
    /// </summary>
    public class ViewLocalizer : IViewLocalizer, ICanHasViewContext
    {
        private readonly IHtmlLocalizerFactory _localizerFactory;
        private readonly string _appName;
        private IHtmlLocalizer _localizer;

        /// <summary>
        /// Creates a new <see cref="ViewLocalizer"/>.
        /// </summary>
        /// <param name="localizerFactory">The <see cref="IHtmlLocalizerFactory"/>.</param>
        /// <param name="appEnv">The <see cref="IApplicationEnvironment"/>.</param>
        public ViewLocalizer(IHtmlLocalizerFactory localizerFactory, IApplicationEnvironment appEnv)
        {
            _appName = appEnv.ApplicationName;
            _localizerFactory = localizerFactory;
        }

        /// <inheritdoc />
        public LocalizedString this[string name] => _localizer[name];

        /// <inheritdoc />
        public LocalizedString this[string name, params object[] arguments] => _localizer[name, arguments];

        /// <inheritdoc />
        public LocalizedString GetString(string name) => _localizer.GetString(name);

        /// <inheritdoc />
        public LocalizedString GetString(string name, params object[] values) => _localizer.GetString(name, values);

        /// <inheritdoc />
        public LocalizedHtmlString Html(string key) => _localizer.Html(key);

        /// <inheritdoc />
        public LocalizedHtmlString Html(string key, params object[] arguments) => _localizer.Html(key, arguments);

        /// <inheritdoc />
        public IStringLocalizer WithCulture(CultureInfo culture) => _localizer.WithCulture(culture);

        /// <inheritdoc />
        IHtmlLocalizer IHtmlLocalizer.WithCulture(CultureInfo culture) => _localizer.WithCulture(culture);

        public void Contextualize(ViewContext viewContext)
        {
            var baseName = viewContext.View.Path.Replace('/', '.').Replace('\\', '.');
            if (baseName.StartsWith("."))
            {
                baseName = baseName.Substring(1);
            }
            baseName = _appName + "." + baseName;
            _localizer = _localizerFactory.Create(baseName, _appName);
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
            => _localizer.GetAllStrings(includeAncestorCultures);
    }
}