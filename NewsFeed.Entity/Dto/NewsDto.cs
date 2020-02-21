using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Entity.Dto
{ 
    public class NewsDto
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishDate { get; set; }
    }
}
