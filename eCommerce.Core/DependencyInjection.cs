﻿using eCommerce.Core.RespositoryContracts;
using eCommerce.Core.Service;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }

}

