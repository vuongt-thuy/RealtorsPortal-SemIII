using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your fullname!")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your password again!")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Please enter your phone!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your email!")]
        public string Email { get; set; }

    }
}
