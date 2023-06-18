using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedsWPF.Core
{
    public class FeedsViewBinding
    {
    }

    public class HomeViewBinding
    {
    }

    public class NotificationsViewBinding
    {
    }
    class MainWindowBinding : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand FeedsViewCommand { get; set; }
        public RelayCommand NotificationsViewCommand { get; set; }

        public HomeViewBinding HomeVM { get; set; }
        public FeedsViewBinding FeedsVM { get; set; }
        public NotificationsViewBinding NotificationsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainWindowBinding()
        {
            HomeVM = new HomeViewBinding();
            FeedsVM = new FeedsViewBinding();
            NotificationsVM = new NotificationsViewBinding();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            FeedsViewCommand = new RelayCommand(o => { CurrentView = FeedsVM; });
            NotificationsViewCommand = new RelayCommand(o => { CurrentView = NotificationsVM; });

        }
    }
}
