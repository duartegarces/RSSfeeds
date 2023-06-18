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

namespace FeedsWPF.Views
{
    /// <summary>
    /// Interaction logic for FeedsNewsView.xaml
    /// </summary>
    public partial class FeedsNewsView : Window
    {
        public FeedsNewsView()
        {
            InitializeComponent();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ItemsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
