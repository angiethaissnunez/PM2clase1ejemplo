using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace PM2clase1ejemplo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMaps : ContentPage
    {
        public PageMaps()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            /*
            Pin ubicacion = new Pin();
            ubicacion.Label = "San Pedro Sula";
            ubicacion.Address = "Cerca de UTH SPS";
            ubicacion.Position = new Position(15.5510539, -88.0109923);
            mapas.Pins.Add(ubicacion);

            mapas.MoveToRegion(new MapSpan(new Position(15.5510539, -88.0109923), 1,1));
            
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    mapas.MoveToRegion(new MapSpan(new Position(location.Latitude, location.Longitude), 1, 1));

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            
            catch (Exception ex)
            {
                // Unable to get location
            }
            */

            var localizacion = CrossGeolocator.Current; 

            if (localizacion != null) 
            {
                localizacion.PositionChanged += Localizacion_PositionChanged; 

                if (!localizacion.IsListening) 
                { 
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100); 
                } 

                var posicion = await localizacion.GetPositionAsync(); 
                var centromapa = new Position(posicion.Latitude, posicion.Longitude); 
                mapas.MoveToRegion(new MapSpan(centromapa, 1, 1)); 
            } 
            else 
            { 
                var posicion = await localizacion.GetLastKnownLocationAsync(); 
                var centromapa = new Position(posicion.Latitude, posicion.Longitude); 
                mapas.MoveToRegion(new MapSpan(centromapa, 1, 1)); 
            }

        }

        private void Localizacion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e) 
        { 
            var centromapa = new Position(e.Position.Latitude, e.Position.Longitude); 
            mapas.MoveToRegion(new MapSpan(centromapa, 1, 1)); 
        }

    }
}