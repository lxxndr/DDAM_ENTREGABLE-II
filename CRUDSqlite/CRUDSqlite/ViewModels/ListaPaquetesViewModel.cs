using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using CRUDSqlite.Models;
using CRUDSqlite.Views;

namespace CRUDSqlite.ViewModels
{
    public class ListPaquetesViewModel : BaseViewModel
    {
        private ObservableCollection<Paquetes> _paquetes;

        public ObservableCollection<Paquetes> Paquetes
        {
            get { return _paquetes; }
            set { _paquetes = value; OnPropertyChanged(); }
        }

        public Type PaqueteDetallePageType { get; private set; }
        private Paquetes _selectedPaquete;

        public Paquetes SelectedPaquete
        {
            get { return _selectedPaquete; }
            set { _selectedPaquete = value; OnPropertyChanged(); }
        }

        public ICommand GoToDetailsCommand { private set; get; }
        public INavigation Navigation { get; set; }

        public ListPaquetesViewModel(INavigation navigation)
        {
            Navigation = navigation;
            // GoToDetailsCommand = new Command(async () => await GoToDetails());
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            // Aquí debes agregar tus paquetes a la colección, por ejemplo:
            Paquetes = new ObservableCollection<Paquetes>();
            PaqueteDetallePageType = typeof(PaqueteDetallePage);

            Paquetes.Add(new Paquetes()
            {
                idPaquetes = 1,
                namePaqute = "Paquete A",
                unoPaqute = "Viaje a avion",
                dosPaqute = "Transporte a todo el Perú",
                tresPaqute = "Hotel de 4 estrellas",
                fechaVenPaqute = "2023-12-31",
                descripcionPaqute = "Un emocionante paquete de viaje.",
                precioPaqute = "500.0"
            });

            Paquetes.Add(new Paquetes()
            {
                idPaquetes = 2,
                namePaqute = "Paquete B",
                unoPaqute = "Visita a Japon con un vuelo de ida y vuelta",
                dosPaqute = "Un cupon para entrar a los mejores restaurantes",
                tresPaqute = "Viaje de 2 semanas",
                fechaVenPaqute = "2023-11-30",
                descripcionPaqute = "Otro emocionante paquete de viaje.",
                precioPaqute = "600.0"
            });

            Paquetes.Add(new Paquetes()
            {
                idPaquetes = 3,
                namePaqute = "Paquete C",
                unoPaqute = "Macchu Picchu",
                dosPaqute = "Estadia en Hotel",
                tresPaqute = "Comida tipica",
                fechaVenPaqute = "2023-11-30",
                descripcionPaqute = "Viaje a una de las marravillas del mundo!.",
                precioPaqute = "600.0"
            });

            Paquetes.Add(new Paquetes()
            {
                idPaquetes = 4,
                namePaqute = "Paquete Hotel",
                unoPaqute = "Viaje a Cualquier Parte dentro de los limites",
                dosPaqute = "Estadia a los mejores hoteles",
                tresPaqute = "Atencion 24/7",
                fechaVenPaqute = "2023-11-30",
                descripcionPaqute = "Viaje a cualquier parte del mundo!.",
                precioPaqute = "600.0"
            });

            Paquetes.Add(new Paquetes()
            {
                idPaquetes = 5,
                namePaqute = "Paquete EXTRA",
                unoPaqute = "Comida a -30%",
                dosPaqute = "Hoteles de 5 estrellas",
                tresPaqute = "",
                fechaVenPaqute = "2023-11-30",
                descripcionPaqute = "Paquete extra que puedes usar en los demas paquetes.",
                precioPaqute = "600.0"
            });
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedPaquete != null)
            {
                var page = new PaqueteDetallePage();
                page.BindingContext = new PaquetesViewModel()
                {
                    idPaquetes = SelectedPaquete.idPaquetes,
                    namePaqute = SelectedPaquete.namePaqute,
                    unoPaqute = SelectedPaquete.unoPaqute,
                    dosPaqute = SelectedPaquete.dosPaqute,
                    tresPaqute = SelectedPaquete.tresPaqute,
                    fechaVenPaqute = SelectedPaquete.fechaVenPaqute,
                    descripcionPaqute = SelectedPaquete.descripcionPaqute,
                    precioPaqute = SelectedPaquete.precioPaqute
                };

                await Navigation.PushAsync(page);
            }
        }
    }
}
