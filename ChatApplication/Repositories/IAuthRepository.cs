using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;

namespace ChatApplication.Repositories
{
    public interface IAuthRepository
    {
        Task<TblUser> Register(TblUser user);
        Task<TblUser> Login(string username);
        Task<bool> UserExists(string username);
    }
}