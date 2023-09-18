using CRUDSqlite.Models;
using CRUDSqlite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using CRUDSqlite.ViewModels;

namespace CRUDSqlite.ViewModels
{
    public class ListServiciosViewModel : BaseViewModel
    {
        private ObservableCollection<ServicioModel> _servicios;

        public ObservableCollection<ServicioModel> Servicios
        {
            get { return _servicios; }
            set { _servicios = value; OnPropertyChanged(); }
        }

        public Type ServicioDetallePageType { get; private set; }
        private ServicioModel _selectedServicio;

        public ServicioModel SelectedServicio
        {
            get { return _selectedServicio; }
            set { _selectedServicio = value; OnPropertyChanged(); }
        }

        public ICommand GoToDetailsCommand { private set; get; }
        public INavigation Navigation { get; set; }


        public ListServiciosViewModel(INavigation navigation)
        {
            Navigation = navigation;
            //GoToDetailsCommand = new Command(async () => await GoToDetails());
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            // Entra a los campos servicios
            Servicios = new ObservableCollection<ServicioModel>();
            ServicioDetallePageType = typeof(ServicioDetallePage);

            // Aquí debes agregar tus servicios a la colección, por ejemplo:
            Servicios.Add(new ServicioModel()
            {
                idServicios = 1,
                pais = "España",
                destino = "Barcelona",
                fechaPartida = new DateTime(2023, 10, 15),
                precio = 500.0m,
                detalles = "Un emocionante viaje a Barcelona.",
                horaLlegada = new DateTime(2023, 10, 16, 12, 0, 0),
                fechaHoraPartida = new DateTime(2023, 10, 15, 9, 0, 0),
                fechaHoraLlegada = new DateTime(2023, 10, 16, 12, 0, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 2,
                pais = "Italia",
                destino = "Roma",
                fechaPartida = new DateTime(2023, 11, 10),
                precio = 600.0m,
                detalles = "Un emocionante viaje a Roma.",
                horaLlegada = new DateTime(2023, 11, 11, 10, 30, 0),
                fechaHoraPartida = new DateTime(2023, 11, 10, 8, 0, 0),
                fechaHoraLlegada = new DateTime(2023, 11, 11, 10, 30, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 3,
                pais = "Francia",
                destino = "París",
                fechaPartida = new DateTime(2023, 12, 5),
                precio = 700.0m,
                detalles = "Explora la Ciudad de la Luz.",
                horaLlegada = new DateTime(2023, 12, 6, 9, 15, 0),
                fechaHoraPartida = new DateTime(2023, 12, 5, 11, 0, 0),
                fechaHoraLlegada = new DateTime(2023, 12, 6, 9, 15, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 4,
                pais = "Estados Unidos",
                destino = "Nueva York",
                fechaPartida = new DateTime(2023, 9, 25),
                precio = 800.0m,
                detalles = "Descubre la Gran Manzana.",
                horaLlegada = new DateTime(2023, 9, 26, 8, 45, 0),
                fechaHoraPartida = new DateTime(2023, 9, 25, 10, 30, 0),
                fechaHoraLlegada = new DateTime(2023, 9, 26, 8, 45, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 5,
                pais = "Japón",
                destino = "Tokio",
                fechaPartida = new DateTime(2023, 11, 20),
                precio = 1200.0m,
                detalles = "Sumérgete en la cultura japonesa en Tokio.",
                horaLlegada = new DateTime(2023, 11, 21, 14, 30, 0),
                fechaHoraPartida = new DateTime(2023, 11, 20, 10, 0, 0),
                fechaHoraLlegada = new DateTime(2023, 11, 21, 14, 30, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 6,
                pais = "Australia",
                destino = "Sídney",
                fechaPartida = new DateTime(2024, 3, 15),
                precio = 950.0m,
                detalles = "Explora la belleza de Sídney y sus playas.",
                horaLlegada = new DateTime(2024, 3, 16, 12, 15, 0),
                fechaHoraPartida = new DateTime(2024, 3, 15, 8, 30, 0),
                fechaHoraLlegada = new DateTime(2024, 3, 16, 12, 15, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 7,
                pais = "México",
                destino = "Cancún",
                fechaPartida = new DateTime(2023, 7, 10),
                precio = 900.0m,
                detalles = "Relájate en las playas de Cancún.",
                horaLlegada = new DateTime(2023, 7, 11, 11, 0, 0),
                fechaHoraPartida = new DateTime(2023, 7, 10, 7, 30, 0),
                fechaHoraLlegada = new DateTime(2023, 7, 11, 11, 0, 0)
            });

            Servicios.Add(new ServicioModel()
            {
                idServicios = 8,
                pais = "Canadá",
                destino = "Toronto",
                fechaPartida = new DateTime(2024, 1, 5),
                precio = 1100.0m,
                detalles = "Descubre la diversidad de Toronto.",
                horaLlegada = new DateTime(2024, 1, 6, 13, 45, 0),
                fechaHoraPartida = new DateTime(2024, 1, 5, 9, 15, 0),
                fechaHoraLlegada = new DateTime(2024, 1, 6, 13, 45, 0)
            });
        }

        //async Task GoToDetails()
        async Task GoToDetails(Type pagetype)
        {
            if (SelectedServicio != null)
            {
                // var page = new ServicioDetallePage();
                // page.BindingContext = new ServicioViewModel();

                // var page = (Page)Activator.CreateInstance(pageType);
                //
                //var page = new ServicioDetallePage();
                var page = (Page)Activator.CreateInstance(pagetype);

                page.BindingContext = new ServicioViewModel()
                {
                    //
                    idServicio = SelectedServicio.idServicios,
                    pais = SelectedServicio.pais,
                    destino = SelectedServicio.destino,
                    fechaPartida = SelectedServicio.fechaPartida,
                    precio = SelectedServicio.precio,
                    detalles = SelectedServicio.detalles,
                    horaLlegada = SelectedServicio.horaLlegada,
                    fechaHoraPartida = SelectedServicio.fechaHoraPartida,
                    fechaHoraLlegada = SelectedServicio.fechaHoraLlegada
                };


                await Navigation.PushAsync(page);
            }
        }
    }
}
