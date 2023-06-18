using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml;
using System.ServiceModel.Syndication;
using Shared;
using Microsoft.SyndicationFeed.Rss;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows;
using System.ComponentModel;


namespace FeedsWPF.Core
{
    class Controller : ObservableCollection<Data>
    {
        public Controller()
        {
            LoadFeeds();
        }

        private void LoadFeeds()
        {
            var LiveData = new Data();
            var ReadFeed = new Feed();
            var ReadItem = new Item();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\rss_reader";
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
                if (!Directory.Exists(path + "\\offline"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (IOException ex) { ErrorHandler(ex); }
            catch (UnauthorizedAccessException ex) { ErrorHandler(ex); }
            catch (ArgumentException ex) { ErrorHandler(ex); }
            catch (NotSupportedException ex) { ErrorHandler(ex); }
            try
            {
                using (var sr = new StreamReader(path + "\\feeds.csv"))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] split = line.Split(';');
                        string link = split[0];
                        string offlinepath = split[1];
                        if (IsConnectedToInternet())
                        {
                            XmlReader Reader = XmlReader.Create(link);
                            SyndicationFeed Feed = SyndicationFeed.Load(Reader);
                            //Loop a passar por ficheiros xml a implementar
                            ReadFeed.Title = Feed.Title.Text;
                            ReadFeed.LinkFeed = Feed.Links[0].Uri;
                            ReadFeed.Image = Feed.ImageUrl;
                            ReadFeed.TTL = Feed.TimeToLive;
                            ReadFeed.LastBuildDate = Feed.LastUpdatedTime;
                            for (int i = 2; i < 7; i++)
                            {
                                ReadFeed.Keywords.Add(split[i]);
                            }
                            foreach (var item in Feed.Items)
                            {
                                ReadItem.Title = item.Title.Text;
                                ReadItem.LinkBrowser = item.Links[0].Uri;
                                if (item.Summary == null)
                                    ReadItem.Description = string.Empty;
                                else
                                    ReadItem.Description = item.Summary.Text;
                                ReadItem.PubDate = item.PublishDate;
                                ReadFeed.Items.Add(ReadItem);
                            }
                            Reader.Close();
                            LiveData.Feeds.Add(ReadFeed);
                        }
                        else
                        {
                            if (!IsDirectoryEmpty(path))
                            {
                                XmlReader Reader2 = XmlReader.Create(offlinepath);
                                SyndicationFeed Feed = SyndicationFeed.Load(Reader2);
                                //Loop a passar por ficheiros xml a implementar
                                ReadFeed.Title = Feed.Title.Text;
                                ReadFeed.LinkFeed = Feed.Links[0].Uri;
                                ReadFeed.Image = Feed.ImageUrl;
                                ReadFeed.TTL = Feed.TimeToLive;
                                ReadFeed.LastBuildDate = Feed.LastUpdatedTime;
                                for (int i = 2; i < 7; i++)
                                {
                                    ReadFeed.Keywords.Add(split[i]);
                                }
                                foreach (var item in Feed.Items)
                                {
                                    ReadItem.Title = item.Title.Text;
                                    ReadItem.LinkBrowser = item.Links[0].Uri;
                                    if (item.Summary == null)
                                        ReadItem.Description = string.Empty;
                                    else
                                        ReadItem.Description = item.Summary.Text;
                                    ReadItem.PubDate = item.PublishDate;
                                    ReadFeed.Items.Add(ReadItem);
                                }
                                Reader2.Close();
                                LiveData.Feeds.Add(ReadFeed);
                            }
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    Add(LiveData);
                }
            }
            catch (IOException ex) { ErrorHandler(ex); }
            catch (ArgumentException ex) { ErrorHandler(ex); }
            //não esquecer o binding das variáveis, os items irão ser identificados pelo título fazendo
            //não esquecer as palavras chave, iremos ter de fazer split nas strings de modo a encontrar palavras chave ou então na descrição? a ponderar ainda
            //criar a parte da abertura do link da notícia no browser
            //quando os itens são lido é necessário marcar como lido ainda a ver como fazer
            //marcar notificações como lidas após serem visualizadas
        }
        public bool IsConnectedToInternet()
        {
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send("google.pt", 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch
            {
                return result;
            }
            return result;
        }
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        public void ErrorHandler(Exception ex)
        {
            MessageBox.Show("The process failed: {0}" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Current.Shutdown();
        }
    }
}
