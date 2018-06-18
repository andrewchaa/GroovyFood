using System;

namespace Domain
{
    public static class EnvironmentVariables
    {
        static Func<string, string> Get = (key) => Environment.GetEnvironmentVariable(key);

        public static string ApiBaseUri => "https://api.gdax.com";
        public static string ApiKey => Get("api_key");
        public static string ApiSecret => Get("api_secret");
        public static string Passphrase => Get("passphrase");
    }
}
