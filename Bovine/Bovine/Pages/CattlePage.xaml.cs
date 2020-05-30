using Bovine.Controls;
using Bovine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bovine.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CattlePage : ContentPage
    {
        ObservableCollection<Cattle> cattles = new ObservableCollection<Cattle>();
        public ObservableCollection<Cattle> Cattles { get { return cattles;  } }

        public CattlePage()
        {
            InitializeComponent();

            //cattles.Add(new Cattle(1, "Mimosa", 400));
            //cattles.Add(new Cattle(2, "Rainha", 300));
            //cattles.Add(new Cattle(3, "Abelha", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(5, "Rei", 500));
            //cattles.Add(new Cattle(6, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(4, "Bandido", 500));
            //cattles.Add(new Cattle(9, "Bandido", 500));

            listViewCattle.ItemsSource = cattles;
        }        

        async void OnButtonAddClicked(object sender, EventArgs e)
        {            
            if (CattleDetailPage.instance == null)
            {
                CattleDetailPage.buttonDeleteVisibility = false;
                var page = new NavigationPage(CattleDetailPage.GetInstance());               
                page.BarBackgroundColor = Color.FromHex("0078D7");                
                await Navigation.PushModalAsync(page);
            }            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listViewCattle.ItemsSource = await App.CattleDatabase.GetCattlesAsync();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewCattle.SelectedItem != null)
            {
                if (CattleDetailPage.instance == null)
                {
                    CattleDetailPage.buttonDeleteVisibility = true;
                    var page = new NavigationPage(CattleDetailPage.GetInstance());
                    page.BarBackgroundColor = Color.FromHex("0078D7");
                    page.BindingContext = e.SelectedItem as Cattle;                    
                    listViewCattle.SelectedItem = null;
                    await Navigation.PushModalAsync(page);
                }       
            }
        }
    }
}