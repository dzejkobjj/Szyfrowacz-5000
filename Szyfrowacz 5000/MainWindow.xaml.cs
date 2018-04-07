using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Szyfrowacz_5000
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> usersList;
        public FileInfo fileToEncrypt { get; set; }
        public FileInfo resultFile { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            usersList = new ObservableCollection<User>();
            UsersListView.ItemsSource = usersList;

        }
        private void AddUserHandler(object sender, RoutedEventArgs e)
        {
            PasswordDialogWindow subWindow = new PasswordDialogWindow();
            string password;
            password = subWindow.ShowPasswordDialog();
            if(password != null)
            {
                usersList.Add(new User(UserNameTextBox.Text, password));
                UserNameTextBox.Text = "";
            }
        }

        private void DeleteUserHandler(object sender, RoutedEventArgs e)
        {
            int id = UsersListView.SelectedIndex;
            if(id != -1)
                usersList.RemoveAt(id);
        }

        private void CheckLength(object sender, TextChangedEventArgs e)
        {
            if (UserNameTextBox.Text.Length == 0)
                AddPasswordButton.IsEnabled = false;
            else
                AddPasswordButton.IsEnabled = true;
        }

        private void OpenFileHandler(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == true)
            {
                fileToEncrypt = new FileInfo(openFile.FileName);
                //FilePathLabel.Content = fileToEncrypt.FullName;
                setFileDetails();
            }
        }

        private void SaveResultFileHandler(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Szyfrowacz 5000 (*.sz5)|*.sz5";
            if(saveFile.ShowDialog() == true)
            {
                resultFile = new FileInfo(saveFile.FileName);
                ResultFilePathLabel.Content = resultFile.FullName;
            }
        }

        private void setFileDetails()
        {
            FileNameLabel.Content = fileToEncrypt.Name;
            double size = fileToEncrypt.Length;
            size = size / 1000000;
            FileSizeLabel.Content = Math.Round(size, 3) + " MB";
            FileCreationDateLabel.Content = fileToEncrypt.CreationTimeUtc.ToLocalTime();
        }
    }
}
