﻿using SimpleMvc.Framework.Attributes.Validation;

namespace GameStore.App.Infrastructure.Validation
{
    public class RequiredAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new System.ComponentModel
                             .DataAnnotations
                             .RequiredAttribute()
                             .IsValid(value);
        }
    }
}
