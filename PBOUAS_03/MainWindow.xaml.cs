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

namespace PBOUAS_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            Page.Content = new homePage();
        }

        private void Selected_Item(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Content.ToString())
            {
                case "Bill Splitter": Page.Content = new billSplitter(); break;
                case "Expense Tracker": Page.Content = new expenseTracker(); break;
                case "Tax Calculator": Page.Content = new taxCalculator(); break;
                default: Page.Content = new homePage(); break;

            }
        }
    }
}
