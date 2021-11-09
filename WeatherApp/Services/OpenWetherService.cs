using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class OpenWetherService : IWindDataService
    {
        private static OpenWeatherProcessor owp;
        public WindDataModel LastWindData;

        public OpenWetherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }
        public async Task<WindDataModel> GetDataAsync()
        {
            Task<OWCurrentWeaterModel> task = owp.GetCurrentWeatherAsync();
            await task;
            return LastWindData = new WindDataModel { DateTime = DateTime.UnixEpoch.AddSeconds(task.Result.DateTime), Direction = task.Result.Wind.Deg, MetrePerSec = task.Result.Wind.Speed };
        }
    }
}