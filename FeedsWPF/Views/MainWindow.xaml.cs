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
using System.ServiceModel.Syndication;
using System.Xml;
using System.Windows.Shapes;
using Shared;


namespace FeedsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;
        public MainWindow()
        {
            InitializeComponent();
            Core.Controller c = new Core.Controller();
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult option;
            option = MessageBox.Show("Are you sure you want to quit the application?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (option == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
