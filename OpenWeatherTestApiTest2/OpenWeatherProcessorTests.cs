using OpenWeatherAPI;
using System;
using Xunit;

namespace OpenWeatherTestApiTest2
{
    public class OpenWeatherProcessorTests
    {
        [Fact]
        public async void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            openWeatherProcessor.ApiKey = "something";
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => openWeatherProcessor.GetOneCallAsync());
        }

        [Fact]
        public async void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            openWeatherProcessor.ApiKey = "something";
            ApiHelper.ApiClient = null;
            await Assert.ThrowsAsync<ArgumentException>(() => openWeatherProcessor.GetCurrentWeatherAsync());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void GetOneCallAsync_ifApiKeyEmptyOrNull_throwArgumentException(string apiKey)
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            ApiHelper.InitializeClient();
            openWeatherProcessor.ApiKey = apiKey;

            await Assert.ThrowsAsync<ArgumentException>(() => openWeatherProcessor.GetOneCallAsync());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void GetCurrentWeatherAsync_ifApiKeyEmptyOrNull_ThrowArgumentException(string apiKey)
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            ApiHelper.InitializeClient();
            openWeatherProcessor.ApiKey = apiKey;

            await Assert.ThrowsAsync<ArgumentException>(() => openWeatherProcessor.GetCurrentWeatherAsync());
        }

        
    }
}
