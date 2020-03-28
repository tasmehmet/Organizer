﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;

namespace Web.Core.ModelBinders
{
    public class LanguageModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (!bindingContext.HttpContext.Items.TryGetValue(AppConstants.LangKey, out object langKey))
                return Task.CompletedTask;

            bindingContext.Result = ModelBindingResult.Success($"{langKey}");
            return Task.CompletedTask;
        }
    }
}