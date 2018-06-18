using System;
using Amazon.Lambda.Core;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Handlers
{
    public class DependencyContainer
    {
        private static IServiceProvider _provider;

        public static IServiceProvider GetServiceProvider(ILambdaLogger logger)
        {
            if (_provider == null)
            {
                var services = new ServiceCollection();
                services.AddSingleton(logger);
                _provider = services.BuildServiceProvider();
            }

            return _provider;
        }
    }
}