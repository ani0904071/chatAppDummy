using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dtos
{
    public class LoginDto
    {

        [Required]
        public string Email { get; set; }

    }
}
