using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedsPage : ContentPage
    {
        public FeedsPage()
        {
            InitializeComponent();
        }

        private void ButtonBack_Clicked(object sender, EventArgs e)
        {
            MainPage Main = new MainPage();
            App.Current.MainPage = Main;
        }
    }
}