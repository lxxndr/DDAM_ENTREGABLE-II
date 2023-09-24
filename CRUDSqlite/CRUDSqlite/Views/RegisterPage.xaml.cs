using CRUDSqlite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace CRUDSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Aquí puedes manejar el evento del botón de regreso como lo desees.
            await Navigation.PopAsync();
        }
        

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Registro registro = new Registro
                {
                    documento = txtNumDocumento.Text,
                    usuario = txtUsuario.Text,
                    email = txtEmail.Text, 
                    celular = txtCelular.Text,
                    contraseña = txtContraseña.Text,
                    
                };
                await App.SQLiteDB.SaveUsuarioAsync(registro);
                txtNumDocumento.Text = "";
                txtUsuario.Text = "";
                txtEmail.Text = "";
                txtCelular.Text = "";
                txtContraseña.Text = "";
                

                await DisplayAlert("Registro", "Se guardo de manera existosa", "OK");

                // var regisList = await App.SQLiteDB.GetRegistrosAsync();
                // if (regisList!=null)
                // {
                //     lstRegistro.ItemsSource = regisList;
                // }
            }


            
            else
            {
                await DisplayAlert("Advertencia", "Ingresar los datos", "OK");
            }
        }
        public bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return emailRegex.IsMatch(email);

        }


        // Campos Obligatorios - No deja campos null
        public bool validarDatos()

        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCelular.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }
            else if (!IsValidEmail(txtEmail.Text)) // Validación del formato de correo electrónico
            {
                DisplayAlert("Error", "El formato del correo electrónico no es válido", "OK");
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }




        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
       
    }
}
