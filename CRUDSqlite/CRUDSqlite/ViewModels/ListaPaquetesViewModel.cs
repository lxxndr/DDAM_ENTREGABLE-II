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
                destino= "",
                pais= "",
                precio="",
                dias=""
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
                };

                await Navigation.PushAsync(page);
            }
        }
    }
}
