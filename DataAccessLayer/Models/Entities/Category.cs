using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter your name!")]
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Ads> Ads { get; set; }
    }
}
