using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Domain.Models;
using GdaxApi.Models;
using GroovyFood.Domain;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Handlers
{
    public class Handler
    {
        private IServiceProvider _services;

        public async Task<IEnumerable<Candle>> Hello(Request request)
        {
            var ratesRepository = new RatesRepository();
            var candles = await ratesRepository.GetDailyRates(request.Coin, request.Days);
            
            Console.WriteLine("Serverless testing");
            
            return candles;
        }
    }

    public class Request
    {
        public int Days {get; set;}
        public Coin Coin {get; set;}
    }
}
