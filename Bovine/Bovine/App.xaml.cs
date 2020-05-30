using Bovine.Data;
using Bovine.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bovine
{
    public partial class App : Application
    {
        static CattleDatabase cattleDatabase;
        static FarmDatabase farmDatabase;

        public static CattleDatabase CattleDatabase
        {
            get
            {
                if (cattleDatabase == null)
                {
                    cattleDatabase = new CattleDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Cattles.db3"));
                }
                return cattleDatabase;
            }
        }

        public static FarmDatabase FarmDatabase
        {
            get
            {
                if (farmDatabase == null)
                {
                    farmDatabase = new FarmDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Farms.db3"));
                }
                return farmDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //(Application.Current).MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
