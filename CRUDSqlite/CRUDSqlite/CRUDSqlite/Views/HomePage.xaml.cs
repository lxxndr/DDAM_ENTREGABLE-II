using CRUDSqlite.Models;
using CRUDSqlite.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDSqlite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        // Variables Login
        private string nombreUsuarioLogeado = "Invitado";

        // acceder al nombre usuario y cambiar label "Invitado" a "Usuario"
        public HomePage(string nombreUsuario)
        {
            InitializeComponent ();
            nombreUsuarioLogeado = nombreUsuario;
            lblUsuario.Text = nombreUsuarioLogeado;

            // Activar Paquetes :>
            if (!string.IsNullOrEmpty(nombreUsuarioLogeado))
            {
                btnPaquetes.IsEnabled = true;

                // desaparecer opciones logeo
                lblRegistro.IsVisible = false;
                lblLogearte.IsVisible = false;
                lblTexto.IsVisible = false;

                lblDeslogearte.IsVisible = true;
            }
        }

        private async void btnServicios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciosPage());
        }

        private async void btnPaquetes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync (new PaquetesPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }
    }
}