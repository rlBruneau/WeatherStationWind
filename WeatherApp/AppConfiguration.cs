using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        public static string GetValue(String conf)
        {
            if (configuration == null)
                InitConfig();
            return configuration.GetValue<string>(conf);
        }

        private static void InitConfig()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).AddUserSecrets("e0a86c66-f550-437b-a2c9-3260f364ea05", true).Build();
        }
    }
}
