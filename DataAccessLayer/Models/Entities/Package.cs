using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Priority")]
        [Required(ErrorMessage = "Please enter your Priority!")]
        public int Priority { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter your Name!")]
        public string Name { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Please enter your Price!")]
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Ads> Ads { get; set; }
    }
}
