using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2clase1ejemplo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListEmple : ContentPage
    {
        public PageListEmple()
        {
            InitializeComponent();
        }

        //Evento load de un content page

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listemple.ItemsSource = await App.DatabaseEmp.ListaEmpleados();
        }
        private async void tooladd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private async void listemple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.Empleado emple = (Models.Empleado)e.CurrentSelection.FirstOrDefault();

            MainPage pag = new MainPage();
            pag.BindingContext = emple;
            await Navigation.PushAsync(pag);

        }

        private async void toolmap_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageMaps());
        }
    }
}