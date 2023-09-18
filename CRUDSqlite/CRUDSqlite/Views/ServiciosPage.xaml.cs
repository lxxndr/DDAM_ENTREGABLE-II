using CRUDSqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDSqlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiciosPage : ContentPage
    {
        public ServiciosPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.ListServiciosViewModel(Navigation);
            List<ServicioModel> servicioModels = new List<ServicioModel>()
            {
                new ServicioModel(){destino = "Miami", pais="https://miamidiario.com/wp-content/uploads/Waldorf-Astoria-Miami.jpg", precio="s/ 1300"},
                new ServicioModel(){destino = "Machu Pichu", pais="https://img.freepik.com/fotos-premium/restos-arqueologicos-machu-picchu-ubicados-montanas-cusco-peru_56619-1204.jpg?w=2000",precio="s/ 2100"},
                new ServicioModel(){destino = "Madrid", pais="https://img.freepik.com/fotos-premium/madrid-espana-26-marzo-2019-vista-vertical-calles-centro-madrid_608742-180.jpg?w=2000", precio = "s/ 3200"},
            };
            Carousel.ItemsSource = servicioModels;
        }
    }
}