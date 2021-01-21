using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dtos
{
    public class RegisterDto
    {

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "FirstName must be at least 2 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be at least 5 characters")]
        public string Email { get; set; }
        [Required]
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName must be at least 3 characters")]
        public string LastName { get; set; }
    }
}
