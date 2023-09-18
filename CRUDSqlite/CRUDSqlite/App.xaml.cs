using CRUDSqlite.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDSqlite
{
    public partial class App : Application
    {
        static SQLiteHelper _connetion;
        public App()
        {
            InitializeComponent();

            // MainPage = new HomePage();
            MainPage = new NavigationPage(new LoginPage());
            
        }

        // 
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (_connetion == null)
                {
                    _connetion = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpresaTurista.db3"));
                }
                return _connetion;
            }
        }
        // aqui me quede

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
