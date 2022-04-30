using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Nordek.Models;
using Nordek.Stores;
using Nordek.ViewModels;

namespace Nordek
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Users = SqliteDataAccess.LoadUsers();
            
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

           base.OnStartup(e);
        }
    }
}
