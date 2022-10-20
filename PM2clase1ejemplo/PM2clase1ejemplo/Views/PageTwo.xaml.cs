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
    public partial class PageTwo : ContentPage
    {
        public PageTwo()
        {
            InitializeComponent();
        }
        public PageTwo(String nombre, String Apellido)
        {
            InitializeComponent();
            lbresultado.Text = nombre + " " + Apellido;
        }
    }
}