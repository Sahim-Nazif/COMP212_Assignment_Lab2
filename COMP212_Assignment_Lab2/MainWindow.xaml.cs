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

namespace COMP212_Assignment_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creating local variables
        double amount, balance;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Transaction(object sender, RoutedEventArgs e)
        {
            //setting variables
            amount = double.Parse(txtAmount.Text);
            balance = double.Parse(txtBalance.Text);
            
            /*Creating dialog messages to be passed in MessageBox*/
            string withdrawFromSaving = "Do you want to withdraw $" + amount + " from " + rdSaving.Content;
            string withdrawFromChequing= "Do you want to withdraw $" + amount + " from " + rdChequing.Content;
            string depositToSaving= "Do you want to desposit $" + amount + "to " + rdSaving.Content;
            string depositToChequing = "Do you want to desposit $" + amount + "to " + rdChequing.Content;
            string withdrawalError = "You can not withdraw the amount exceeded the balance";
            string cancelOperation = "You choose to exit the application. Have a good day!";
            string improperInput = "Please check the amount you are trying to enter";

           if(rdSaving.IsChecked==true && rdWithdraw.IsChecked==true && rdChequing.IsChecked==false)
            {
                MessageBoxResult result = MessageBox.Show(withdrawFromSaving, "Important Query", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (amount > balance)
                        {
                            MessageBox.Show(withdrawalError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        else if (amount <= balance)
                        {
                            txtBalance.Text = (balance - double.Parse(txtAmount.Text)).ToString();
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show(cancelOperation, "Exit", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                    default:
                        break;

                }
            }
            else if(rdChequing.IsChecked==true && rdWithdraw.IsChecked==true && rdSaving.IsChecked==false)
            {
                MessageBoxResult result = MessageBox.Show(withdrawFromChequing, "Important Query", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (amount > balance)
                        {
                            MessageBox.Show(withdrawalError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        else if (amount <= balance)
                        {
                            txtBalance.Text = (balance - double.Parse(txtAmount.Text)).ToString();
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show(cancelOperation, "Exit", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                    default:
                        break;

                }
            }
            else if (rdSaving.IsChecked==true && rdDeposit.IsChecked==true && rdChequing.IsChecked == false)
            {
                if(amount<=0 || string.IsNullOrEmpty(txtAmount.Text))
                {
                    MessageBox.Show(improperInput, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else 
                {
                    MessageBoxResult result = MessageBox.Show(depositToSaving, "Important Query", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            txtBalance.Text = (balance + double.Parse(txtAmount.Text)).ToString();
                            break;
                        case MessageBoxResult.No:
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        /*Will close the application*/
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for using the application. Have a good day", "Exit", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.Hide();

        }
    }
}
