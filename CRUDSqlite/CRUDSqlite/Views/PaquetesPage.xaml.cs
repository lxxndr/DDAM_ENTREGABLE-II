using CRUDSqlite.Models;
using CRUDSqlite.ViewModels;
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
    public partial class PaquetesPage : ContentPage
    {
        public PaquetesPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.ListPaquetesViewModel(Navigation);
            List<Paquetes> Paquetes= new List<Paquetes>()
    {
            new Paquetes(){local="Francia", destino = "Marsella", pais="https://funci.org/wp-content/uploads/2022/05/Marsella-panoramica-1024x683.jpg", precio="s/ 1300", dias =""},
            new Paquetes(){local="Argentina",destino = "Buenos aires", pais="https://blogskystorage.s3.amazonaws.com/2021/07/skyairline_skyairline_image_182.jpeg",precio="s/ 2100", dias =""},
            new Paquetes(){local="Italia",destino = "Roma", pais="https://www.thetrainline.com/cms/media/1353/italy-rome-colosseum.jpg?mode=crop&width=660&height=440&quality=70", precio = "s/ 3200", dias =""},
    };
            Carousel.ItemsSource = Paquetes;
        }

    }
    
}