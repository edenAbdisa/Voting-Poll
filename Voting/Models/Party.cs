using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using  System.Web;

namespace Voting.Models
{
    public class Party
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartyId { get; set; }
        [Required]
        [Display(Name = "Party Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Path { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(10550, ErrorMessage = "The {0} must be atleast {2} and at max {1} characters long.")]
        public string Description { get; set; }

        [Display(Name = "Upload Party Image")]
        [NotMappedAttribute]
        public IFormFile ImageFile { get; set; }

        [Required]
        [Display(Name = "Running for Election")]
        public int ElectionId { get;set;}

    }
}
