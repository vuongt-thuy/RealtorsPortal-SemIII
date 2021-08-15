using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Models.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your fullname!")]
        public string Fullname { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }
        [DisplayName("Phone")]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Please enter the correct format, for example: 0935444999!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your email!")]
        [RegularExpression("^[\\w\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Please enter the correct format, for example: demo@gmail.com!")]
        public string Email { get; set; }
        [DisplayName("Avatar")]
        public string Avt { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public string Company { get; set; }
        [Required]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public int PaypalConfig { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("RoleId")]
        public UserRole UserRole { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
