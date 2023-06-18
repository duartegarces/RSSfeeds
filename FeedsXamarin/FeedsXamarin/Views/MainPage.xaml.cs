using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Shared;

namespace FeedsXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonFeeds_Clicked(object sender, EventArgs e)
        {
            Views.FeedsPage Feeds = new Views.FeedsPage();
            App.Current.MainPage = Feeds;
        }
    }
}
