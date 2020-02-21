using NewsFeed.Entity.Dto;
using NewsFeed.Presenter.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Presenter.Interfaces
{
    public interface IRssNews
    {
        RssNewsPresenter Presenter { get; }
        List<NewsDto> DataSource { set; }
        string NewsTitle { get; set; }
        int NewsId { get; set; }
        string RssUrl { get; set; }
        void OnError(string erroMessage);
    }
}
