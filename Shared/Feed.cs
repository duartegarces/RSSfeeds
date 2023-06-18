using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Shared
{
    public class Feed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string title_;
        private Uri linkfeed_;
        private TimeSpan? ttl_;
        private ObservableCollection<Item> items_;
        private ObservableCollection<Notification> notifications_;
        private ObservableCollection<string> keywords_;
        private Uri image_;
        private DateTimeOffset lastbuild_;

        public Feed()
        {
            notifications_ = new ObservableCollection<Notification>();
            items_ = new ObservableCollection<Item>();
            keywords_ = new ObservableCollection<string>();
        }
        public string Title
        {
            get { return title_; }
            set
            {
                title_ = value;
                OnPropertyChanged("Title");
            }
        }
        public Uri LinkFeed
        {
            get { return linkfeed_; }
            set
            {
                linkfeed_ = value;
                OnPropertyChanged("Link Feed");
            }
        }
        public TimeSpan? TTL
        {
            get { return ttl_; }
            set
            {
                ttl_ = value;
                OnPropertyChanged("TTL");
            }
        }
        public ObservableCollection<Item> Items
        {
            get { return items_; }
            set
            {
                items_ = value;
                OnPropertyChanged("Items");
            }
        }

        public ObservableCollection<Notification> Notifications
        {
            get { return notifications_; }
            set
            {
                notifications_ = value;
                OnPropertyChanged("Notifications");
            }
        }
        public ObservableCollection<string> Keywords
        {
            get { return keywords_; }
            set
            {
                keywords_ = value;
                OnPropertyChanged("Keywords");
            }
        }
        public Uri Image
        {
            get { return image_; }
            set
            {
                image_ = value;
                OnPropertyChanged("Image");
            }
        }
        public DateTimeOffset LastBuildDate
        {
            get { return lastbuild_; }
            set
            {
                lastbuild_ = value;
                OnPropertyChanged("LastBuild");
            }
        }
    }
}
