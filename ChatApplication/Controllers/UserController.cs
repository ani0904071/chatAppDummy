using System;

using System.Threading.Tasks;

using ChatApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApplication.Dtos;
using AutoMapper;
using ChatApplication.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ChatApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IChatDetailsRepository _chatRepo;
        private readonly IMapper _mapper;
        public UserController(UserContext context, IMapper mapper, IChatDetailsRepository repo)
        {
            _context = context;
            _mapper = mapper;
            _chatRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var data = await _context.TblUser.ToListAsync();
            return Ok(data);
        }

        [HttpPost("SendText")]
        public async Task<IActionResult> SendText(ChatDetailsDto chatDetailsDto)
        {
            var textToCreate = _mapper.Map<TblChatDetails>(chatDetailsDto);
            textToCreate.CreatedAt = DateTime.Now;
            var sentText = await _chatRepo.sendText(textToCreate);

            return StatusCode(201, new { id = sentText.ChatId, sentAt = sentText.CreatedAt, chatMessage = sentText.ChatText, to = sentText.ToUserId });
        }

        [HttpGet]
        [Route("RerieveTexts/{fromUserID:int}/{toUserID:int}")]
        public async Task<IActionResult> RerieveChats(int fromUserID, int toUserID)
        {

            var query = await (from ct in _context.TblChatDetails
                         join u1 in _context.TblUser
                         on ct.FromUserId equals u1.UserId
                         join u2 in _context.TblUser
                         on ct.ToUserId equals u2.UserId
                         select new
                         {
                             textId = ct.ChatId,
                             senderId = u1.UserId,
                             sentBy = u1.FirstName,
                             textMessage = ct.ChatText,
                             sentAt = ct.CreatedAt,
                             receiverId = u2.UserId,
                             receivedBy = u2.FirstName
                         }).Where(param => (param.senderId == fromUserID && param.receiverId == toUserID) || (param.receiverId == fromUserID && param.senderId == toUserID) ).ToListAsync();

            return Ok(query);

        }


    }
            


}
