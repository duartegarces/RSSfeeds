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
using System.Timers;

namespace FeedsWPF.Views
{
    /// <summary>
    /// Interaction logic for FeedsView.xaml
    /// </summary>
    public partial class FeedsView : UserControl
    {
        //adicionar messagebox a confirmar a remoção do feed
        public FeedsView()
        {
            InitializeComponent();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            FeedAddView add = new FeedAddView();
            add.Show();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to remove this feed?", "RSS Feeds", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result==MessageBoxResult.Yes)
            {

            }
            
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            FeedEditView edit = new FeedEditView();
            edit.Show();
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e) //Aparecer dados na listbox
        {
            FeedsList.Items.Add("RTP Feed");
            FeedsList.Items.Add("Reddit Feed");
            FeedsList.Items.Add("Sic Notícias Feed");
            FeedsList.Items.Add("TVI24 Feed");
        }

        private void FeedsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FeedsNewsView FeedsItems = new FeedsNewsView();
            FeedsItems.ShowDialog();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                
            }
        }
    }
}
