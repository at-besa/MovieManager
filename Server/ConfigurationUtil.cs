using System;
using Microsoft.Extensions.Configuration;

namespace MovieManager.Server
{
    public static class ConfigurationUtil
    {
        private static IConfiguration configuration;

        public static IConfiguration GetConfiguration() =>
            configuration ?? throw new EntryPointNotFoundException("No configuration applied, initialize first.");

        public static void SetConfiguration(IConfiguration config)
        {
            configuration = config;
        }

    }
}
