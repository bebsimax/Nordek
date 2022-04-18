using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nordek.Models;

namespace Nordek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            string path =  System.IO.Directory.GetCurrentDirectory ();
            this.UsersList.Items.Add(path);
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=TestDb.db;Version=3;");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                return;
            }
            
            SQLiteCommand cmd;
            string getUsers = "SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%';";

            cmd = sqlite_conn.CreateCommand();
            cmd.CommandText = getUsers;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string myreader = reader.GetString(0);
                this.UsersList.Items.Add(myreader);
                
            }
            sqlite_conn.Close();
        }


        private void LoadUsersButton_OnClick(object sender, RoutedEventArgs e)
        {
            var Users = SqliteDataAccess.LoadUsers();
            foreach (var user in Users)
            {
                this.UsersList.Items.Add(user);
            }
        }
    }
}