// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNet.Mvc.Localization
{
    public interface IHtmlLocalizerFactory
    {
        IHtmlLocalizer Create(Type resourceSource);
        IHtmlLocalizer Create(string baseName, string location);
    }
}