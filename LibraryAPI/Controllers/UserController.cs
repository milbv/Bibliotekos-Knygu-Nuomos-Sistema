using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetAllUsers")]
        public List<User> Index()
        {
            return _userRepository.GetAll();
        }
        [HttpGet("GetByUserById")]
        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}
