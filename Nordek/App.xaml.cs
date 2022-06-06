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
            SqliteDataAccess.SetupConnection();
            NavigationStore navigationStore = new NavigationStore();
            var activeUser = SqliteDataAccess.GetActiveUser();
            
            if (activeUser.Count==0)
            {
                navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            }
            else
            {
                Globals.ActiveUser = activeUser[0];
                
                navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
                
            }
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

           base.OnStartup(e);
        }
    }
}
