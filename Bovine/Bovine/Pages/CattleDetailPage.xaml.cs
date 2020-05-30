using Bovine.Behaviors;
using Bovine.Enums;
using Bovine.Models;
using Bovine.Models.Animal;
using Newtonsoft.Json;
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
    public partial class CattleDetailPage : ContentPage
    {
        int pickerSpecieSelectedIndex = 0;
        int pickerSexSelectedIndex = 0;
        public static bool buttonDeleteVisibility;

        private CattleDetailPage()
        {
            InitializeComponent();            
            labelID.IsVisible = false;
            entryID.IsVisible = false;
            pickerSex.SelectedIndex = 0;
            pickerSpecie.SelectedIndex = 0;
            labelErrorIdentifier.IsVisible = false;
            buttonDelete.IsVisible = buttonDeleteVisibility;
        }

        #region Singleton
        //turn this page in a singleton class instance
        public static CattleDetailPage instance = null;
        private static readonly object _lock = new object();
        public static CattleDetailPage GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new CattleDetailPage();
                }

                return instance;
            }
        }
        #endregion
                
        private void OnPickerSpecieSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            pickerSpecieSelectedIndex = picker.SelectedIndex;
            if (pickerSpecieSelectedIndex == 0) // se leiteiro, somente fêmea
            {
                pickerSex.SelectedIndex = 0;
            }
        }

        private void OnPickerSexSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            pickerSexSelectedIndex = picker.SelectedIndex;
            if (pickerSexSelectedIndex == 1) // se macho, somente corte
            {
                pickerSpecie.SelectedIndex = 1;
            }
        }        

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {            
            await Navigation.PopModalAsync();
            instance = null;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (!identifierValidator.IsValid)
            {
                entryIdentifier.Focus();
                labelErrorIdentifier.IsVisible = true;
                return;
            }

            float weight;

            float.TryParse(entryWeight.Text, out weight);

            if (!string.IsNullOrWhiteSpace(entryID.Text))
            {
                await App.CattleDatabase.SaveCattleAsync(new Cattle
                {                    
                    ID = int.Parse(entryID.Text),
                    Identifier = entryIdentifier.Text,
                    Specie = (Specie)pickerSpecieSelectedIndex,
                    BirthDate = datePickerBirthdate.Date,
                    Sex = (Enums.Sex)pickerSexSelectedIndex,
                    //Weight = float.Parse(entryWeight.Text,System.Globalization.NumberStyles.Float),
                    Weight = weight,
                });
            }
            else
            {
                await App.CattleDatabase.SaveCattleAsync(new Cattle
                {
                    Identifier = entryIdentifier.Text,
                    Specie = (Specie)pickerSpecieSelectedIndex,
                    BirthDate = datePickerBirthdate.Date,
                    Sex = (Enums.Sex)pickerSexSelectedIndex,
                    Weight = weight,
                });
            }
            await Navigation.PopModalAsync();
            instance = null;
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Cattle cattle = (Cattle)BindingContext;
            await App.CattleDatabase.DeleteCattleAsync(cattle);
            await Navigation.PopModalAsync();
            instance = null;
        }

        private bool ValidateIdentifier()
        {
            if (string.IsNullOrWhiteSpace(entryIdentifier.Text))
                return false;
            else
                return true;
        }        

        async void OnJsonButtonClicked(object sender, EventArgs e)
        {
            string id = "0003";
            string species = "cattle";
            string legalID = entryIdentifier.Text;
            DateTime birthdate = datePickerBirthdate.Date;
            string sex = pickerSex.SelectedItem.ToString();
            double[] location = await GetPositionAsync();
            _ = Task.Delay(1000);
            double weight;
            double.TryParse(entryWeight.Text, out weight);
            Animal animal = new Animal(id, species, legalID, birthdate, sex, location, weight);

            string output = JsonConvert.SerializeObject(animal, Formatting.Indented);

            labelJson.Text = output;

            frameJson.IsVisible = true;
        }

        async Task<double[]> GetPositionAsync()
        {
            Geocoder geocoder = new Geocoder();

            IEnumerable<Position> approximateLocations = await geocoder.GetPositionsForAddressAsync("Rua Saquarema - Centro, Diadema - SP");
            Position position = approximateLocations.FirstOrDefault();

            double[] coordinates = { position.Latitude, position.Longitude };

            return coordinates;
            //string coordinates = $"{position.Latitude}, {position.Longitude}";
        }

        protected override bool OnBackButtonPressed()
        {
            instance = null;
            return base.OnBackButtonPressed();
        }
    }
}