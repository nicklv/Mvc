﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Framework.Localization;
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNet.Mvc.Localization
{
    public interface IValidationAttributeLocalizer<TAttribute, TResourceSource>
        where TAttribute : ValidationAttribute
    {
        LocalizedString FormatMessage(ValidationAttributeLocalizationContext<TAttribute> context);
    }

    public interface IValidationLocalizer<TAttribute>
        where TAttribute : ValidationAttribute
    {
        LocalizedString FormatMessage(ValidationAttributeLocalizationContext<TAttribute> context);
    }

    public class ValidationAttributeLocalizationContext<TAttribute>
        where TAttribute : ValidationAttribute
    {
        public IStringLocalizer Localizer { get; set; }

        public ValidationContext ValidationContext { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public TAttribute Attribute { get; set; }
    }
}