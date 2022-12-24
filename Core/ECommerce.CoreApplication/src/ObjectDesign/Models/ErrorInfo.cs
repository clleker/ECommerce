// <copyright file="ErrorInfo.cs" company="KocSistem">
// Copyright (c)  All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace ECommerce.CoreApplication.ObjectDesign
{
    [Serializable]
    public class ErrorInfo
    {
        public ErrorInfo()
        {
        }

        public ErrorInfo(string message)
        {
            this.Message = message;
        }

        public ErrorInfo(int code)
        {
            this.Code = code;
        }

        public ErrorInfo(int code, string message)
            : this(message)
        {
            this.Code = code;
        }

        public ErrorInfo(string message, string details)
            : this(message)
        {
            this.Details = details;
        }

        public ErrorInfo(int code, string message, string details)
            : this(message, details)
        {
            this.Code = code;
        }

        public int Code { get; set; }

        public string Details { get; set; }

        public string Message { get; set; }

        public IEnumerable<ValidationErrorInfo> ValidationErrors { get; set; }

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

            return obj.GetType() == this.GetType() && this.Equals((ErrorInfo)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( this.Code, this.Message, this.Details, this.ValidationErrors);
        }

        protected bool Equals(ErrorInfo other)
        {
            return other != null  && this.Code == other.Code && this.Message == other.Message && this.Details == other.Details && Equals(this.ValidationErrors, other.ValidationErrors);
        }
    }
}
