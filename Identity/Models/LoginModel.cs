using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class LoginModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}