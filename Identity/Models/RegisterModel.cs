using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class RegisterModel
    {
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

    }
}