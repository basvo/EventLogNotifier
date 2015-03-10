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

namespace EventLogNotifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnApply_Click(object sender, RoutedEventArgs e)
        {
            // Apply the configuration settings
            throw new NotImplementedException();
        }

        private void bnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close without doing anything
            this.Close();
        }
    }
}
