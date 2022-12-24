// <copyright file="ValidationErrorInfo.cs" company="KocSistem">
// Copyright (c)  All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace ECommerce.CoreApplication.ObjectDesign
{
    [Serializable]
    public class ValidationErrorInfo
    {
        public ValidationErrorInfo()
        {
        }

        public ValidationErrorInfo(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((ValidationErrorInfo)obj);
        }

        public override int GetHashCode()
        {
            return this.Message != null ? this.Message.GetHashCode() : 0;
        }

        protected bool Equals(ValidationErrorInfo other)
        {
            return other != null && this.Message == other.Message;
        }
    }
}
