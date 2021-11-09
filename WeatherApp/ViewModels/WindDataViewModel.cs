using System.Threading.Tasks;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {
        public IWindDataService WindDataService { get; set; }
        public DelegateCommand<string> GetDataCommand { get; set; }
        private WindDataModel currentData;
        public WindDataModel CurrentData
        {
            get => currentData;
            set
            {
                currentData = value;
                OnPropertyChanged();
            }
        }


        public WindDataViewModel()
        {
            WindDataService = new OpenWetherService(AppConfiguration.GetValue("apiKey"));
            GetDataCommand = new DelegateCommand<string>(LoadContent);
        }

        public double KPHtoMPS(double kph) => kph * 1.0 / 36.0;
        public double MPStoKPH(double mps) => mps * 3.6;

        private async void LoadContent(string str)
        {
            CurrentData = await WindDataService.GetDataAsync();
        }
        

    }
}
