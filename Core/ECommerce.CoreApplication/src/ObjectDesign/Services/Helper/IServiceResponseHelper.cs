// <copyright file="IServiceResponseHelper.cs" company="KocSistem">
// Copyright (c)  All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace ECommerce.CoreApplication.ObjectDesign.Services
{
    public interface IServiceResponseHelper 
    {
        ServiceResponse SetSuccess();

        ServiceResponse<T> SetSuccess<T>(T data);

        ServiceResponse<T> SetError<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError, bool isLogging = false);

        ServiceResponse SetError(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError, bool isLogging = false);

        ServiceResponse SetError(ErrorInfo errorItem, bool isLogging = false);

        ServiceResponse<T> SetError<T>(T data, ErrorInfo errorInfo, bool isLogging = false);
    }
}
