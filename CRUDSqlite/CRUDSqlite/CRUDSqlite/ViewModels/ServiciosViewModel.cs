using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CRUDSqlite.ViewModels
{
    public class ServicioViewModel : BaseViewModel
    {
        private int _idServicio;
        public int idServicio
        {
            get { return _idServicio; }
            //set { SetProperty(ref _idServicio, value); }
            set { _idServicio = value; OnPropertyChanged(); }
        }

        private string _pais;
        public string pais
        {
            get { return _pais; }
            //set { SetProperty(ref _pais, value); }
            set { _pais =  value; OnPropertyChanged(); }
        }

        private string _destino;
        public string destino
        {
            get { return _destino; }
            //set { SetProperty(ref _destino, value); }
            set { _destino = value; OnPropertyChanged(); }
        }

        private DateTime _fechaPartida;
        public DateTime fechaPartida
        {
            get { return _fechaPartida; }
            //set { SetProperty(ref _fechaPartida, value); }
            set { _fechaPartida = value; OnPropertyChanged(); }
        }

        private decimal _precio;
        public decimal precio
        {
            get { return _precio; }
            //set { SetProperty(ref _precio, value); }
            set { _precio = value; OnPropertyChanged(); }
        }

        private string _detalles;
        public string detalles
        {
            get { return _detalles; }
            //set { SetProperty(ref _detalles, value); }
            set { _detalles = value; OnPropertyChanged(); }
        }

        private DateTime _horaLlegada;
        public DateTime horaLlegada
        {
            get { return _horaLlegada; }
            //set { SetProperty(ref _horaLlegada, value); }
            set { _horaLlegada = value; OnPropertyChanged(); }
        }

        private DateTime _fechaHoraPartida;
        public DateTime fechaHoraPartida
        {
            get { return _fechaHoraPartida; }
            //set { SetProperty(ref _fechaHoraPartida, value); }
            set { _fechaPartida = value; OnPropertyChanged(); }
        }

        private DateTime _fechaHoraLlegada;
        public DateTime fechaHoraLlegada
        {
            get { return _fechaHoraLlegada; }
            //set { SetProperty(ref _fechaHoraLlegada, value); }
            set { _fechaHoraPartida = value; OnPropertyChanged(); }
        }



        // limpiar campos
        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }


        public ServicioViewModel()
        {
            ClearCommand = new Command(() => Clear());
            SendEmailCommand = new Command(async () => await SendEmail());
        }

        void Clear()
        {
            idServicio = 0;
            pais = string.Empty;
            destino = string.Empty;
            fechaPartida = DateTime.MinValue;
            precio = 0;
            detalles = string.Empty;
            horaLlegada = DateTime.MinValue;
            fechaHoraPartida = DateTime.MinValue;
            fechaHoraLlegada = DateTime.MinValue;
        }




        async Task SendEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Nuevo Servicio!",
                    Body = $"ID del Servicio: {idServicio}\nPaís: {pais}\nDestino: {destino}\nFecha de Partida: {fechaPartida}\nPrecio: {precio:N2}\nDetalles: {detalles}\nHora de Llegada: {horaLlegada}\nFecha y Hora de Partida: {fechaHoraPartida}\nFecha y Hora de Llegada: {fechaHoraLlegada}",
                    To = new List<string> { "tu@email.com" }
                };

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                //
            }
            
        }
    }
}
