using AutoMapper;
using ChatApplication.Dtos;
using ChatApplication.Models;

namespace ChatApplication.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginDto, TblUser>();
            CreateMap<RegisterDto, TblUser>();
            CreateMap<ChatDetailsDto, TblChatDetails>();
        }
    }
}
