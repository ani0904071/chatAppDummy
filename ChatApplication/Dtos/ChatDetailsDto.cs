using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dtos
{
    public class ChatDetailsDto
    {
        [Required]
        public int FromUserId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Text must be at least 1 characters")]
        public string ChatText { get; set; }

        [Required]
        public int ToUserId { get; set; }
    }
}
