using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Models
{
    public class Comment
    {
        [Key]
        public int commentId{get;set;}


        public int PartyId { get; set; }
        
        public string UserName { get; set; }


        public string CommentData { get; set; }

        public DateTime dateTime { get; set; }
        
    }
}
