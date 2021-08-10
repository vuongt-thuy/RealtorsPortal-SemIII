using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdsId { get; set; }
        public PackageOfUser PackageOfUserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //[ForeignKey("PackageOfUserId")]
        //public virtual PackageOfUser PackageOfUser { get; set; }

        [ForeignKey("AdsId")]
        public virtual Ads Ads { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
