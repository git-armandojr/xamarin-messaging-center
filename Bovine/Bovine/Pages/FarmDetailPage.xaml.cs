using Bovine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Bovine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FarmDetailPage : ContentPage
    {
        Geocoder geocoder;
        public static bool buttonDeleteVisibility;
        public FarmDetailPage()
        {
            InitializeComponent();
            labelID.IsVisible = false;
            entryID.IsVisible = false;

            _ = GetAddressAsync().Wait(100);
            buttonDelete.IsVisible = buttonDeleteVisibility;
        }

        #region Singleton
        //turn this page in a singleton class instance
        public static FarmDetailPage instance = null;
        private static readonly object _lock = new object();
        public static FarmDetailPage GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new FarmDetailPage();
                }

                return instance;
            }
        }
        #endregion

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryID.Text))
            {
                await App.FarmDatabase.SaveFarmAsync(new Farm
                {
                    ID = int.Parse(entryID.Text),
                    Name = entryName.Text,
                    Description = entryDescription.Text,
                    Street = entryStreet.Text,
                    Locality = entryLocality.Text,
                    Country = entryCountry.Text
                });
            }
            else
            {
                await App.FarmDatabase.SaveFarmAsync(new Farm
                {
                    Name = entryName.Text,
                    Description = entryDescription.Text,
                    Street = entryStreet.Text,
                    Locality = entryLocality.Text,
                    Country = entryCountry.Text
                });
            }
            await Navigation.PopModalAsync();
            instance = null;
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Farm farm = (Farm)BindingContext;
            await App.FarmDatabase.DeleteFarmAsync(farm);
            await Navigation.PopModalAsync();
            instance = null;
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            instance = null;
        }

        async Task<double[]> GetPositionAsync()
        {
            geocoder = new Geocoder();

            IEnumerable<Position> approximateLocations = await geocoder.GetPositionsForAddressAsync("Rua Saquarema - Centro, Diadema - SP");
            Position position = approximateLocations.FirstOrDefault();

            double[] coordinates = { position.Latitude, position.Longitude };

            return coordinates;
            //string coordinates = $"{position.Latitude}, {position.Longitude}";
        }

        private async Task GetAddressAsync()
        {
            Geocoder geoCoder = new Geocoder();

            double[] coordinates = await GetPositionAsync();

            Position position = new Position(coordinates[0], coordinates[1]);
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            //entryStreet.Text = possibleAddresses.FirstOrDefault();
        }

        protected override bool OnBackButtonPressed()
        {
            instance = null;
            return base.OnBackButtonPressed();
        }
    }
}