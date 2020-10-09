using SalariesDll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace ProjetSyntheseWPF
{
    /// <summary>
    /// Logique d'interaction pour ConnectDialog.xaml
    /// </summary>
    public partial class ConnectDialog : Window
    {
        
        public enum typeError
        {
            AllOk = 0,
            WrongdId = 1,
            WrongMdp = 2,
            BlockedAccount = 3,
            HasNoRole = 4,
        }

        string currentId;
        string currentMdp;
        typeError acces;
        public Utilisateur current;
        Utilisateurs adressListsUsers = MainWindow.listUsers;
       

        public ConnectDialog()
        {
            InitializeComponent();
            //ObservableCollection <Utilisateur> observableListUsers = new ObservableCollection<Utilisateur>(MainWindow.listUsers);
            //isClickable(btnValider);
        }

        #region Evenements
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            currentId = txtBoxIdentifiant.Text;
            currentMdp = txtBoxMdp.Text;

            Utilisateur utilisateurCurrent = getUtilisateur(currentId, adressListsUsers) ;

            connexion(currentId, utilisateurCurrent);

            switch (acces)
            {
                case typeError.WrongdId:
                    ErrorLog("Ouais d'accord mais l'identifiant n'existe pas en fait !", "Wrong Id");
                    break;
                case typeError.WrongMdp:
                    ErrorLog("Mauvais mot de passe, concentre toi un peu", "Mauvais mot de passe");
                    utilisateurCurrent.NombreEchecsConsecutifs += 1;
                    if (utilisateurCurrent.NombreEchecsConsecutifs < 3)
                    {
                        ErrorLog($"Tentatives restantes: {3 - utilisateurCurrent.NombreEchecsConsecutifs}", "Tentatives");
                    }
                    if(utilisateurCurrent.NombreEchecsConsecutifs >= 3)
                    {
                        ErrorLog(@"Ce compte est bloqué. Merci de contacter votre aministrateur. Si c'est vous, dommage ¯\_(ツ)_/¯", "Compte bloqué");
                        utilisateurCurrent.CompteBloque = true;
                    }

                    break;
                case typeError.BlockedAccount:
                    ErrorLog(@"Ce compte est bloqué. Merci de contacter votre aministrateur. Si c'est vous, dommage ¯\_(ツ)_/¯", "Compte bloqué");
                    break;
                case typeError.HasNoRole:
                    ErrorLog("Ce compte n'a pas les autorisations requises. Arrêtez de me faire perdre mon temps !", "Autorisations manquantes");
                    break;
                case typeError.AllOk:
                    utilisateurCurrent.NombreEchecsConsecutifs = 0;
                    this.DialogResult = true;
                    current = utilisateurCurrent;
                    break;
            }

        }
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {

            CancelPage();
        }
        


        private void txtBoxIdentifiant_TextChanged(object sender, TextChangedEventArgs e)
        {
            isClickable(btnValider);
        }
        private void txtBoxMdp_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
        #endregion
        #region Fonctions 
        private void isClickable(Button but)
        {

            if (txtBoxIdentifiant.Text == "" || txtBoxMdp.Text == "")
            {
                but.IsEnabled = false;
            }
            else
            {
                but.IsEnabled = true;
            }
        }
        private Utilisateur getUtilisateur(string Id, Utilisateurs list)
        {

            if (list.UtilisateurByMatricule(Id) == null)
            {
                return null;
            }
            return list.UtilisateurByMatricule(Id);

        }
        private bool ValidatingId(Utilisateur currentUser)
        {
           
            if(currentUser == null)
            {
                return false;
            }
            return true;

        }
        private bool ValidatingMdp(Utilisateur currentUser)
        {
            if (currentUser.MotDePasse != currentMdp)  
            {
               return false;
            }
            return true;
        } 
        private bool IsBlocked(Utilisateur currentUser)
        {
            if (currentUser.CompteBloque == true)
            {
                return true;
            }
            return false;
        }
        private bool HasRole(Utilisateur currentUser, Roles listRole)
        {
            if (listRole.Contains(currentUser.Role))
            {
                return true;
            }
            return false;
        }
        private bool connexion(string Id, Utilisateur utilisateur)
        {

          
            if (!ValidatingId(utilisateur))
            {
                acces = typeError.WrongdId;
                return false;
            }
            if (IsBlocked(utilisateur))
            {
                acces = typeError.BlockedAccount;
                return false;
            }
            if (!ValidatingMdp(utilisateur))
            {
                acces = typeError.WrongMdp;
                return false;
            }
           
            if (!HasRole(utilisateur, MainWindow.listRoles))
            {
                acces = typeError.HasNoRole;
                return false;
            }
            acces = typeError.AllOk;
            return true;
              

        }


        private void ErrorLog(string txt, string titre)
        {

            MessageBox.Show(txt, titre, MessageBoxButton.OK);
;        }
        private void CancelPage()
        {
            MessageBox.Show("La prochaine fois ne tentez pas de vous connecter si vous n'avez pas de compte ( ಠ ʖ̯ ಠ)", "Adieu", MessageBoxButton.OK);
            System.Environment.Exit(1);
            
        }
        

#endregion


    }

}
