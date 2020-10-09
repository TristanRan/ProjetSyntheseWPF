using SalariesDll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProjetSyntheseWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Utilisateurs listUsers = new Utilisateurs();
        public static Roles listRoles = new Roles();
       public static Salaries listSalaries = new Salaries();
        public static ConnectDialog connect = new ConnectDialog();


        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            
            //Initialisation Roles//
            Role admin = new Role() { Identifiant = "administrateur", Description = "Accès total à l'applicaton" };
            Role limitedUser = new Role() { Identifiant = "utilisateur", Description = "Accès interdit au panneau utilisateur" };
            listRoles.Add(admin);
            listRoles.Add(limitedUser);

            //Initialisation Users//
            Utilisateur ran = new Utilisateur("aa111bb", "Ranchon", "00000");
            
            listUsers.Add(ran);
            listUsers.Add(new Utilisateur("bb0000bb", "Machin", "11111"));
            ran.Role = admin;

            Salarie tri = new Salarie("Ranchon", "Tristan", "11aaa22");
            tri.Poste = "Salarie";
            listSalaries.Add(tri);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        //    connect.ShowDialog();

        //    if (connect.DialogResult == true)
        //    {

        //        Utilisateur currentUser = connect.current;
        //        MessageBox.Show($"Bienvenue, {currentUser.Nom}");

        //    }
        }
      

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PageSalarie pageSalarie = new PageSalarie();
            
            Main.Content = pageSalarie;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }

}
