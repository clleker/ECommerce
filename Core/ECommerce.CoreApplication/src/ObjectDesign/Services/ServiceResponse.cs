// <copyright file="ServiceResponse.cs" company="KocSistem">
// Copyright (c)  All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace ECommerce.CoreApplication.ObjectDesign.Services
{
    [Serializable]
    public class ServiceResponse
    {
        public ServiceResponse(bool isSuccessful = true)
        {
            this.IsSuccessful = isSuccessful;
        }

        public ServiceResponse(ErrorInfo error, bool isSuccessful = false)
        {
            this.Error = error;
            this.IsSuccessful = isSuccessful;
        }

        public ErrorInfo Error { get; set; }

        public bool IsSuccessful { get; set; }

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

            return obj.GetType() == this.GetType() && this.Equals((ServiceResponse)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IsSuccessful, this.Error);
        }

        protected bool Equals(ServiceResponse other)
        {
            return this.IsSuccessful == other?.IsSuccessful && Equals(this.Error, other?.Error);
        }
    }
}
