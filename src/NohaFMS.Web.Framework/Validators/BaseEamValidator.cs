/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using FluentValidation;

namespace NohaFMS.Web.Framework.Validators
{
    public abstract class BaseEamValidator<T> : AbstractValidator<T> where T : class
    {
        protected BaseEamValidator()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
