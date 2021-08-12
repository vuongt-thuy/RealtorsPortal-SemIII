using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    [Table("Ads")]
    public class Ads
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string DetailAddress { get; set; }
        public int LandArea { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PackageId { get; set; }
        public int CategoryId { get; set; }
        public string Need { get; set; }
        public string UnitPrice { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int WardId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package Package { get; set; }

        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
