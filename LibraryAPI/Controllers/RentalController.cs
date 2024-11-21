using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using LibraryAPI.Core.Repositories;
using LibraryAPI.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentService _rentService;
        public RentalController(IRentService rentService)
        {
            _rentService = rentService;
        }
        [HttpGet("GetAllRents")]
        public List<RentRecord> Index()
        {
            return _rentService.GetAllRents();
        }
        [HttpPost("AddRentalRecord")]
        public void AddRentRecord(RentRecord rental)
        {
            _rentService.AddRentRecord(rental);
        }
        [HttpPost("EndRent")]
        public void EndRent(int id)
        {
            _rentService.EndRent(id);
        }
        [HttpGet("GetActiveRentByClient")]
        public RentRecord? GetActiveRentByClient(int clientId)
        {
            return _rentService.GetActiveRentByClient(clientId);
        }
        [HttpGet("GetAllRentsByClient")]
        public List<RentRecord> GetAllRentsByClient(int clientId)
        {
            return _rentService.GetAllRentsByClient(clientId);
        }
        [HttpGet("GetAllClientsByBook")]
        public List<User> GetAllClientsByBook(int bookId)
        {
            return _rentService.GetAllClientsByBook(bookId);
        }
    }
}
