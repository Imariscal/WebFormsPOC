using NewsFeed.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Model.IRepository
{
    public interface ICommentsRepository
    {
        IEnumerable<Comments> GetComments(int newId);
        Comments GetCommentId(int commentId);
        void InsertComment(Comments comment);
        void UpdateComment(Comments comment);
        void DeleteComment(int commentId);
        void Save();
    }
}
