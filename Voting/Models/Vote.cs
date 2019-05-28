using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

         
        public int PartyId { get; set; }
        public int ElectionId { get; set; }
        public string UserName { get; set; }
        public DateTime dateTime { get; set; }

    }
}
