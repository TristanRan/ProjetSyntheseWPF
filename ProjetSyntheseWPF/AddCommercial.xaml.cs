using SalariesDll;
using System;
using System.Collections.Generic;
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

namespace ProjetSyntheseWPF
{
    /// <summary>
    /// Logique d'interaction pour AddCommercial.xaml
    /// </summary>
    public partial class AddCommercial : Window
    {
        private Commercial addedCommercial;


        public Commercial AddedCommercial
        {
            get { return (Commercial)this.Resources["newCommercial"]; }
        }


        public AddCommercial()
        {
            InitializeComponent();
            
            dpDateNaissance.DisplayDateStart = new DateTime(1900, 1, 1);
            dpDateNaissance.DisplayDateEnd = DateTime.Today.AddYears(-15);
            dpDateNaissance.DisplayDate = new DateTime(1990, 1, 1);
            dpDateNaissance.Text = "01/01/1990";
            AddedCommercial.DateNaissance = dpDateNaissance.DisplayDate;
            txtBoxId.Text = String.Empty;


        }
        private bool isEmpty()
        {

            if (txtBoxId.Text != "")
            {
                return true;

            }
            txtBoxId.Text = "Id invalide. Format : xx000xx";
            return false;

        }

        private int cptErreursValidation = 0;
        private void Erreur_Validation(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                cptErreursValidation++;
            else
                cptErreursValidation--;
        }

        private void btnAddSalarieToList_Click(object sender, RoutedEventArgs e)
        {
            if (cptErreursValidation == 0 && isEmpty())
            {
                AddedCommercial.Poste = "Commercial";
                MainWindow.listSalaries.Add(AddedCommercial);
                this.Close();
                AddedCommercial.ToString();
            }
        }

        private void btnAnnulerAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
