using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Shared
{
    public class Notification:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string title_;
        private DateTimeOffset date_;
        private bool archived_;

        public string Title
        {
            get { return title_; }
            set
            {
                title_ = value;
                OnPropertyChanged("Title");
            }
        }
        public DateTimeOffset Date
        {
            get { return date_; }
            set
            {
                date_ = value;
                OnPropertyChanged("Date");
            }
        }
        public bool Archived
        {
            get { return archived_; }
            set
            {
                archived_ = value;
                OnPropertyChanged("Archived");
            }
        }
    }
}
