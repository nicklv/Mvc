// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.AspNet.Mvc.Localization;
using Microsoft.Framework.WebEncoders;

namespace Microsoft.Framework.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHtmlLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IHtmlLocalizerFactory, HtmlLocalizerFactory>();
            services.AddTransient(typeof(IHtmlLocalizer<>), typeof(HtmlLocalizer<>));
            services.AddTransient(typeof(IViewLocalizer), typeof(ViewLocalizer));
            if (!services.Any(sd => sd.ServiceType == typeof(IHtmlEncoder)))
            {
                services.AddInstance<IHtmlEncoder>(HtmlEncoder.Default);
            }
            return services.AddLocalization();
        }
    }
}