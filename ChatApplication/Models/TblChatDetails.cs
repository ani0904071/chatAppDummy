using System;

namespace ChatApplication.Models
{
    public class TblChatDetails
    {
        public int ChatId { get; set; }
        public DateTime CreatedAt  { get; set; }
        public int FromUserId { get; set; }
        public String ChatText { get; set; }
        public int ToUserId { get; set; }
    }
}
