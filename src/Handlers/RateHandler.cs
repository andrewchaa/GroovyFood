using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Domain.Models;
using GdaxApi.Models;
using GroovyFood.Domain;
using Handlers.ViewModels;
using SanPellgrino;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Handlers
{
    public class RateHandler
    {
        public async Task<IEnumerable<Candle>> Hello(Request request)
        {
            var ratesRepository = new RatesRepository();
            var candles = await ratesRepository.GetDailyRates(request.Coin, request.Days);
            
            Console.WriteLine("Serverless testing");
            
            return candles;
        }

        public async Task<IEnumerable<Candle>> Daily(int days)
        {
            var ratesRepository = new RatesRepository();

            var candles = new List<Candle>();
            candles.AddRange(await ratesRepository.GetDailyRates(Coin.BTC, days));
            candles.AddRange(await ratesRepository.GetDailyRates(Coin.ETH, days));
            candles.AddRange(await ratesRepository.GetDailyRates(Coin.LTC, days));
            
            return candles;
        }
    }
}
