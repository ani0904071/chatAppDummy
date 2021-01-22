using System.Threading.Tasks;
using ChatApplication.Models;


namespace ChatApplication.Repositories
{
    public class ChatDetailsRepository : IChatDetailsRepository
    {
        private readonly UserContext _context;

        public ChatDetailsRepository(UserContext context)
        {
            _context = context;
        }


        public async Task<TblChatDetails> sendText(TblChatDetails tblChatDetails)
        {
         
            await _context.TblChatDetails.AddAsync(tblChatDetails);
            await _context.SaveChangesAsync();

            return tblChatDetails;
        }

    }
}
