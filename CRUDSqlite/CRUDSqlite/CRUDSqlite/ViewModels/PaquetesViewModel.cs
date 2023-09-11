using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUDSqlite.ViewModels
{
    public class PaquetesViewModel : BaseViewModel
    {
        private int _idPaquetes;
        public int idPaquetes
        {
            get { return _idPaquetes; }
            set { _idPaquetes = value; OnPropertyChanged(); }
        }

        private string _namePaqute;
        public string namePaqute
        {
            get { return _namePaqute; }
            set { _namePaqute = value; OnPropertyChanged(); }
        }

        private string _unoPaqute;
        public string unoPaqute
        {
            get { return _unoPaqute; }
            set { _unoPaqute = value; OnPropertyChanged(); }
        }

        private string _dosPaqute;
        public string dosPaqute
        {
            get { return _dosPaqute; }
            set { _dosPaqute = value; OnPropertyChanged(); }
        }

        private string _tresPaqute;
        public string tresPaqute
        {
            get { return _tresPaqute; }
            set { _tresPaqute = value; OnPropertyChanged(); }
        }

        private string _fechaVenPaqute;
        public string fechaVenPaqute
        {
            get { return _fechaVenPaqute; }
            set { _fechaVenPaqute = value; OnPropertyChanged(); }
        }

        private string _descripcionPaqute;
        public string descripcionPaqute
        {
            get { return _descripcionPaqute; }
            set { _descripcionPaqute = value; OnPropertyChanged(); }
        }

        private string _precioPaqute;
        public string precioPaqute
        {
            get { return _precioPaqute; }
            set { _precioPaqute = value; OnPropertyChanged(); }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }

        public PaquetesViewModel()
        {
            ClearCommand = new Command(() => Clear());
            SendEmailCommand = new Command(async () => await SendEmail());
        }

        void Clear()
        {
            idPaquetes = 0;
            namePaqute = string.Empty;
            unoPaqute = string.Empty;
            dosPaqute = string.Empty;
            tresPaqute = string.Empty;
            fechaVenPaqute = string.Empty;
            descripcionPaqute = string.Empty;
            precioPaqute = string.Empty;
        }

        async Task SendEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "New Package!",
                    Body = $"Package Name: {namePaqute}\nPrice: {precioPaqute}\nDescription: {descripcionPaqute}",
                    To = new List<string> { "tu@email.com" }
                };

                await Email.ComposeAsync(message);
            }
            catch (Exception)
            {
                // Maneja cualquier excepción que pueda ocurrir al enviar el correo.
            }
        }
    }
}