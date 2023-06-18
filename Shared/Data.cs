using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace Shared
{
    public class Data:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private ObservableCollection<Feed> feeds_;

        public Data()
        {
            feeds_ = new ObservableCollection<Feed>();
        }

        public ObservableCollection<Feed> Feeds
        {
            get { return feeds_; }
            set
            {
                feeds_ = value;
                OnPropertyChanged("Feeds");
            }
        }
    }
}
