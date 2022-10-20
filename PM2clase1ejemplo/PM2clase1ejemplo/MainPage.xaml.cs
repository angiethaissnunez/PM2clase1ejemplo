using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2clase1ejemplo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnmostrar_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                id = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                apellido = txtapellidos.Text,
                telefono = txtcelular.Text
            };

             var result = await App.DatabaseEmp.StoreEmple(emple);

            if (result >0)
            {
                await DisplayAlert("Empleado Ingresado", "Correcto ", "Ok");
            }
            else
                await DisplayAlert("Error", "no Ingresado", "Ok");

             
        }

        private async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                id = 1, nombre = txtnombre.Text, apellido = txtapellidos.Text
            };

            var pagetwo = new Views.PageTwo();
            pagetwo.BindingContext = emple;
            await Navigation.PushAsync(pagetwo);


           /*await Navigation.PushAsync(new Views.PageTwo(txtnombre.Text, txtapellidos.Text));*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

    }
}
