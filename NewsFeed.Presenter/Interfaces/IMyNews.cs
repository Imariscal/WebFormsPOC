using NewsFeed.Entity.Models;
using NewsFeed.Presenter.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Presenter.Interfaces
{
    public interface IMyNews
    {
        MyNewsPresenter Presenter { get;  }
        List<News> DataSource { set; }
   
        string Comment { get; set; }
        int NewsId { get; set; }
        int CommentId { get; set; }
        List<Comments> CommentsDataSource { set; }
        void OnError(string errorMessage);

    }
}
