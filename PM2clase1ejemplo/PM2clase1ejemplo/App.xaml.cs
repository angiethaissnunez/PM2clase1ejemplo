using PM2clase1ejemplo.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2clase1ejemplo
{
    public partial class App : Application
    {
        static Controllers.EmpleController databaseEmple;

        public static Controllers.EmpleController DatabaseEmp
        {
            get
            { 
            
                if(databaseEmple == null)
                {
                    databaseEmple = 
                        new Controllers.EmpleController(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Emple.db3"));
                }
                return databaseEmple;

            }
        }
        public App()
        {
            InitializeComponent();

           //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new PageListEmple());
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
