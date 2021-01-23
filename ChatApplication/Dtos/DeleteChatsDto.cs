using System.ComponentModel.DataAnnotations;

namespace ChatApplication.Dtos
{
    public class DeleteChatsDto
    {
        [Required]
        public int FromUserId { get; set; }

        [Required]
        public int[] ChatIDs { get; set; }
    }
}
