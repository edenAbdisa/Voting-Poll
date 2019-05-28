using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Models
{
    public class Election
    {
        [Key]
        public int ElectionId { get; set; }

        [Required]
        [Display(Name = "Electon Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }        
        
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
        public string Status { get; set; }

    }
}
