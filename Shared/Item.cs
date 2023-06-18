using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Shared
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string title_;
        private Uri linkbrowser_;
        private DateTimeOffset pubdate_;
        private string description_;
        private bool asread_;

        public string Title
        {
            get { return title_; }
            set
            {
                title_ = value;
                OnPropertyChanged("Title");
            }
        }
        public Uri LinkBrowser
        {
            get { return linkbrowser_; }
            set
            {
                linkbrowser_ = value;
                OnPropertyChanged("LinkBrowser");
            }
        }
        public DateTimeOffset PubDate
        {
            get { return pubdate_; }
            set
            {
                pubdate_ = value;
                OnPropertyChanged("PubDate");
            }
        }
        public string Description
        {
            get { return description_; }
            set
            {
                description_ = value;
                OnPropertyChanged("Description");
            }
        }
        public bool AsRead
        {
            get { return asread_; }
            set
            {
                asread_ = value;
                OnPropertyChanged("AsRead");
            }
        }
    }
}
