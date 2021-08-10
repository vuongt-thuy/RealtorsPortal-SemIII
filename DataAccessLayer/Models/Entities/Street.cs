using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    [Table("Street")]
    public class Street
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WardId { get; set; }

        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }

        public ICollection<Street> Streets { get; set; }
        public ICollection<Ads> Ads { get; set; }
    }
}
