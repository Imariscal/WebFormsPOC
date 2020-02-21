using NewsFeed.Entity.Models;
using NewsFeed.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Model.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private NewsFeedContext _context = null;
    
        public CommentsRepository()
        {
            this._context = new NewsFeedContext();
           
        }
       
        public IEnumerable<Comments> GetComments(int newId)
        {
            return _context.Comments.Where(c => c.NewsId == newId);
        }

        public Comments GetCommentId(int commentId)
        {
            return _context.Comments.Find(commentId);
        }

        public void InsertComment(Comments comment)
        {
            _context.Comments.Add(comment);
        }

        public void UpdateComment(Comments comment)
        {
            _context.Comments.Attach(comment);
            _context.Entry(comment).State = EntityState.Modified;
        }

        public void DeleteComment(int commentId)
        {
            var comment = _context.Comments.Where(c => c.Id == commentId).FirstOrDefault();
            _context.Comments.Remove(comment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
