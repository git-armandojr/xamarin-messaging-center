using Bovine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bovine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FarmPage : ContentPage
    {
        ObservableCollection<Farm> farms = new ObservableCollection<Farm>();
        public ObservableCollection<Farm> Farms { get { return farms; } }

        public FarmPage()
        {
            InitializeComponent();

            listViewFarm.ItemsSource = farms;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listViewFarm.ItemsSource = await App.FarmDatabase.GetFarmsAsync();
        }

        private async void OnButtonAddClicked(object sender, EventArgs e)
        {
            if (FarmDetailPage.instance == null)
            {
                //FarmDetailPage.buttonDeleteVisibility = false;
                var page = new NavigationPage(FarmDetailPage.GetInstance());
                page.BarBackgroundColor = Color.FromHex("0078D7");
                await Navigation.PushModalAsync(page);
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewFarm.SelectedItem != null)
            {
                if (FarmDetailPage.instance == null)
                {
                    FarmDetailPage.buttonDeleteVisibility = true;
                    var page = new NavigationPage(FarmDetailPage.GetInstance());
                    page.BarBackgroundColor = Color.FromHex("0078D7");
                    page.BindingContext = e.SelectedItem as Farm;
                    listViewFarm.SelectedItem = null;
                    await Navigation.PushModalAsync(page);
                }
            }
        }
    }
}