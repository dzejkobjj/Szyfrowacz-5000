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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Szyfrowacz_5000
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class PasswordDialogWindow : Window
    {
        private string password;
        private Regex regex;
        private const string REGULAR_EXPRESSION = "((?=.*\\d)(?=.*[a-zA-Z])(?=.*[@#$%]).{8,20})";
        public PasswordDialogWindow()
        {
            regex = new Regex(REGULAR_EXPRESSION);
            InitializeComponent();
        }
        
        public string ShowPasswordDialog()
        {
            this.ShowDialog();
            return password;
        }

        private void VerifyPassword(object sender, RoutedEventArgs e)
        {
            if (!regex.IsMatch(PasswordTextBox.Password))
            {
                PasswordVerifyLabel.Content = "Min. 8 znaków, cyfra, @#$%";
                AcceptButton.IsEnabled = false;
            }
            else if(!PasswordTextBox.Password.Equals(RepeatPasswordTextBox.Password))
            {
                PasswordVerifyLabel.Content = "Hasło są różne";
                AcceptButton.IsEnabled = false;
            } 
            else
            {
                PasswordVerifyLabel.Content = "";
                AcceptButton.IsEnabled = true;
            }
        }

        private void AcceptHandler(object sender, RoutedEventArgs e)
        {
            this.password = PasswordTextBox.Password;
            this.Close();
        }

        private void CancelHandler(object sender, RoutedEventArgs e)
        {
            this.password = null;
            this.Close();
        }

    }
}
