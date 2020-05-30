using Bovine.ViewModels;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Bovine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasturePage : ContentPage
    {
        ObservableCollection<Position> positions = new ObservableCollection<Position>();

        public PasturePage()
        {
            InitializeComponent();
            BindingContext = new PinItemsSourcePageViewModel();
            GetLocation();
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
            positions.Add(e.Position);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = e.Position,
                Label = string.Format("{0}, {1}", e.Position.Latitude.ToString(), e.Position.Longitude.ToString()),
                //Address = "unknown",                
            };

            map.Pins.Add(pin);

            MessagingCenter.Send(pin, "AddItem");
        }

        private async void GetLocation()
        {
            Plugin.Geolocator.Abstractions.Position position = null;
            Position _position;
            try
            {
                var permissions = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (permissions != PermissionStatus.Granted)
                {
                    permissions = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (permissions != PermissionStatus.Granted)
                {
                    return;
                }

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 10;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    _position = new Position(position.Latitude, position.Longitude);

                    map.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMiles(0.04)));

                    //var pin = new Pin
                    //{
                    //    Type = PinType.Place,
                    //    Position = _position,
                    //    Label = string.Format("{0}, {1}", _position.Latitude.ToString(), _position.Longitude.ToString()),
                    //    //Address = "unknown",
                    //};

                    //map.Pins.Add(pin);

                    //map.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMiles(0.04)));

                    //map.IsShowingUser = true;

                    return;
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                throw ex;
                //Display error as we have timed out or can't get location.
            }

            _position = new Position(position.Latitude, position.Longitude);

            if (position == null)
                return;
        }
    }
}