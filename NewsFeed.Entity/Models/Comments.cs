using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Entity.Models
{
    public class Comments
    {
        public int Id { get; set; }
     
        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        public int NewsId { get; set; }

        [ForeignKey("NewsId")]
        public virtual  News News { get; set; }
    }
}
