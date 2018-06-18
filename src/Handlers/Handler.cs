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
            var candles = await ratesRepository.GetDailyRates(Coin.ETH, 10);
            
            Console.WriteLine("Serverless testing");
            return candles;
        }
    }

    public class Response
    {
      public string Message {get; set;}
      public Request Request {get; set;}

      public Response(string message, Request request){
        Message = message;
        Request = request;
      }
    }

    public class Request
    {
      public string Key1 {get; set;}
      public string Key2 {get; set;}
      public string Key3 {get; set;}

      public Request(string key1, string key2, string key3){
        Key1 = key1;
        Key2 = key2;
        Key3 = key3;
      }
    }
}
