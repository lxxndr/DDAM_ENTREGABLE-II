using CRUDSqlite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUDSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Registro registro = new Registro
                {
                    usuario = txtUsuario.Text,
                    nombre = txtNombre.Text,
                    apellidoPaterno = txtApellidoPaterno.Text,
                    apellidoMaterno = txtApellidoMaterno.Text,
                    fechNacimiento = txtFechNac.Text,
                    celular = int.Parse(txtCelular.Text),
                    documento = txtNumDocumento.Text,
                    contraseña = txtContraseña.Text,
                    //cconfirmar = txtCContraseña.Text,
                    email = txtEmail.Text, 
                };
                await App.SQLiteDB.SaveUsuarioAsync(registro);
                txtUsuario.Text = "";
                txtNombre.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtFechNac.Text = "";
                txtNumDocumento.Text = "";
                txtCelular.Text = "";
                txtContraseña.Text = "";
                txtEmail.Text = "";

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

        // Campos Obligatorios - No deja campos null
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtApellidoMaterno.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtFechNac.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtCelular.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCContraseña.Text))
            {
                respuesta = false;
            }else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }else if (txtContraseña.Text != txtCContraseña.Text) // jajajajaja
            {
                respuesta = false;
            }

            else { respuesta = true; }
            return respuesta;
            
        }
    }
}
