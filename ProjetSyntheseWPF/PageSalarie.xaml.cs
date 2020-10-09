using SalariesDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour PageSalarie.xaml
    /// </summary>
    public partial class PageSalarie : Page
    {

        public bool editMode = false;

        public PageSalarie()
        {
            InitializeComponent();
            lbSalaries.ItemsSource = MainWindow.listSalaries;
        }

        private void txtName_MouseUp(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;
            currentTextBox.IsReadOnly = false;
        }

        private void addSalarie_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.listSalaries[0].Nom = "Lalalala";
            AddSalarie addSalarie = new AddSalarie();
            addSalarie.Show();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddCommercial add = new AddCommercial();
            add.Show();
        }

        private void btnEraseSalarie_Copy_Click(object sender, RoutedEventArgs e)
        {
            
           MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir supprimer la selection ?", "Confirmation", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                var list = lbSalaries.ItemsSource as Salaries;

                for (int i = lbSalaries.SelectedItems.Count - 1; i >= 0; i--)
                {
                    Salarie item = lbSalaries.SelectedItems[i] as Salarie;
                    list.Remove(item);
                }
            }


            
        } 
    }
}   


