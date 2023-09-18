﻿using System;
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
        }
    }
}