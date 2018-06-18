using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Domain;
using Domain.Models;
using FunctionalWay.Extensions;
using GdaxApi.Authentication;
using GdaxApi.Clients;
using GdaxApi.Models;
using SanPellgrino;

namespace GroovyFood.Domain
{
    public interface IRatesRepository
    {
        Task<IList<Candle>> GetDailyRates(Coin coin, int days);
        Task<ProductPrice> GetCurrentPrice(string productId);
    }


    public class RatesRepository : IRatesRepository
    {
        private readonly ILambdaLogger _logger;
        private readonly RequestAuthenticator _authenticator;

        public RatesRepository(ILambdaLogger logger)
        {
            _logger = logger;
            _authenticator = (EnvironmentVariables.ApiKey, 
                    EnvironmentVariables.Passphrase, 
                    EnvironmentVariables.ApiSecret)
                .Map(i => new RequestAuthenticator(i));
        }

        public async Task<IList<Candle>> GetDailyRates(Coin coin, int days)
        {
            var client = new ProductClient(EnvironmentVariables.ApiBaseUri, _authenticator);
            var productId = $"{coin.ToUpperString()}-EUR";

            return await client.GetHistoricRatesAsync(productId, DateTimeOffset.UtcNow.AddDays(-1 * (days + 1)),
                DateTimeOffset.UtcNow, TimeSpan.FromDays(1));

        }

        public async Task<ProductPrice> GetCurrentPrice(string productId)
        {
            var client = new ProductClient(EnvironmentVariables.ApiBaseUri, _authenticator);
            var response = await client.GetProductTickerAsync(productId);
            return response.Value;
        }

    }
}