using NewsFeed.Entity.Models;
using NewsFeed.Model.Repository;
using NewsFeed.Presenter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Presenter.Presenter
{
    public class MyNewsPresenter
    {
        private IMyNews view;
        private GenericRepository<News> repository;
        private CommentsRepository commentsRepository;

        public MyNewsPresenter(IMyNews _view)
        {
            view = _view;
            repository = new GenericRepository<News>();
            commentsRepository = new CommentsRepository();
        }


        public void LoadMyNews() {

            try
            {
                var news = repository.GetAll();
                this.view.DataSource = news.ToList();

                if (news.Any()) {
                   this.view.NewsId = news.ToList().First().Id;
                   LoadViewComments();
                }
            }
            catch (Exception ex) {

                this.view.OnError(ex.Message);
            }
        
        }

        public void LoadViewComments()
        {
            try
            {
                int newsId = this.view.NewsId;            

                var comments = commentsRepository.GetComments(newsId);

                if (comments != null) {
                    this.view.CommentsDataSource = comments.ToList();
                }

            }
            catch (Exception ex)
            {
                this.view.OnError(ex.Message);
            }
        }

        public void AddComment() {

            try
            {
                int newsId = this.view.NewsId;
                int commentId = this.view.CommentId;
                string commentDetail = this.view.Comment;

                var comment = new Comments() {
                    Comment = commentDetail,
                    NewsId = newsId,
                    Id = commentId
                };

                if (commentId == 0)
                    commentsRepository.InsertComment(comment);
                else
                    commentsRepository.UpdateComment(comment);

                commentsRepository.Save();
                LoadViewComments();

                this.view.Comment = String.Empty;
                this.view.CommentId = 0;
            }
            catch (Exception ex)
            {
                this.view.OnError(ex.Message);
            }
        }

        public void DeleComment()
        {
            try
            {
                int commmentId = this.view.CommentId;

                commentsRepository.DeleteComment(commmentId);
                commentsRepository.Save();

                LoadViewComments();
                 
                this.view.CommentId = 0;
            }
            catch (Exception ex)
            {
                this.view.OnError(ex.Message);
            }
        }
    }
}
