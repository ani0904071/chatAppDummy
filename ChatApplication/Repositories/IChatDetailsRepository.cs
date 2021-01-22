using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;

namespace ChatApplication.Repositories
{
    public interface IChatDetailsRepository
    {

        Task<TblChatDetails> sendText(TblChatDetails tblChatDetails);
    }
}
