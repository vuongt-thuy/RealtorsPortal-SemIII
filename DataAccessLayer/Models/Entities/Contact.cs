using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your message!")]
        public string Message { get; set; }
        public int? AdsId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("AdsId")]

        public virtual Ads Ads { get; set; }
    }
}
