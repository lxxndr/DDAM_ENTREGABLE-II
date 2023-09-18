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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtContraseña.Text))
            {
                // var usuario = await App.SQLiteDB.GetRegistrosAsync(txtUsuario.Text);
                var usuario = await App.SQLiteDB.GetUsuarioByNombreUsuarioAsync(txtUsuario.Text);

                if (usuario != null)
                {
                    if (txtContraseña.Text == usuario.contraseña)
                    {
                        var nombreUsuarioLogeado = usuario.usuario;
                        
                        await DisplayAlert("Inicio de sesion", "Inicio de seccion exitoso", "OK");

                        // Cambia la raizz de la app
                        Application.Current.MainPage = new NavigationPage(new HomePage(nombreUsuarioLogeado));
                    }
                    else
                    {
                        await DisplayAlert("Advertencia", "Contraseña equivocado, vuelve a intentar", "OK");
                    }
                }else
                {
                    await DisplayAlert("Advertencia", "Usuario equivocado, vuelve a intentar", "OK");
                }
            }else
                {
                    await DisplayAlert("Advertencia", "Por favor, ingrese el usuario y la contraseña", "OK");
                }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync (new ServiciosContraseñaPage());
        }
    }
}