using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    [Table("Ward")]
    public class Ward
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        //public ICollection<Ads> Ads { get; set; }
    }
}
