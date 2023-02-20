using Microsoft.Identity.Client;
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
using TodoWpfApp.Services;

namespace TodoWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AuthenticationResult _AuthenticationInfo = default!;

        public string UserName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginTask = LoginService.LoginAsync();
            loginTask.Wait();
            _AuthenticationInfo = loginTask.Result;
            UserName = _AuthenticationInfo.Account.Username;
        }
    }
}
