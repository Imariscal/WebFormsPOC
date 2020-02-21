using NewsFeed.Entity.Dto;
using NewsFeed.Entity.Models;
using NewsFeed.Model.Repository;
using NewsFeed.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsFeed.Presenter.Presenter
{
    public class RssNewsPresenter
    {
        private IRssNews view;
        private HttpClient client = new HttpClient();
        private GenericRepository<News> repository;
     
        public RssNewsPresenter(IRssNews _view)
        {
            this.view = _view;
            repository = new GenericRepository<News>(); 
        }

        public void LoadNews()
        {
            try
            {

                if (this.view.RssUrl.Trim().Length == 0) {
                    this.view.OnError("Please enter a RSS url");
                    return;
                }

                var news = new List<NewsDto>();
                var id = 1;
                XmlReader reader = XmlReader.Create(this.view.RssUrl);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    news.Add(new NewsDto()
                    {
                        NewsId = id,
                        Summary = item.Summary.Text.Trim(),
                        Title = item.Title.Text.Trim().Replace("'", ""),
                        PublishDate = item.PublishDate.ToString("MM/dd/yyyy HH:mm:ss")
                    });

                    id++;
                }

                this.view.DataSource = news;
            }
            catch (Exception er) {

                this.view.OnError(er.Message);
            }
        }


        public void SubscribeNews() {

            int newsId = this.view.NewsId;
            string title = this.view.NewsTitle;

            try {

                var newsList = repository.GetAll().Where(n => n.Title == title);
                
                if (newsList.Any()) {
                    this.view.OnError("All ready exists a subscription with the title : " + title);
                    return;
                }

                var news = new News()
                {
                    Comments = null,
                    Title = title,
                    Id = newsId
                };

                repository.Insert(news);
                repository.Save();


                this.view.OnError("Subscription Finished");
            }
            catch (Exception er)
            {
                this.view.OnError(er.Message);
            }

        }


        
    }
}
