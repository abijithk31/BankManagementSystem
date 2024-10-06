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

namespace BankManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = FormConfig.accountViewModel;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.createAccountWindow.Show();
            CreateAccountWindow newAccountWindow = (CreateAccountWindow)FormConfig.createAccountWindow;
            FormConfig.accountViewModel.NewWindowClose = newAccountWindow.WindowClose;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //FormConfig.editAccountWindow.Show();
            //EditAccountWindow editAccountWindow = (EditAccountWindow)FormConfig.editAccountWindow;
            //FormConfig.accountViewModel.EditWindowClose = editAccountWindow.WindowClose;

            var viewModel = (AccountViewModel)this.DataContext;
            if (viewModel.SelectedAccount != null)
            {
                var selectedWindow = new EditAccountWindow();
                selectedWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("please select");
            }

        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.depositWindow.Show();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.withdrawWindow.Show();
        }
    }
}
