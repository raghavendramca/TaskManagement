using Microsoft.AspNetCore.Mvc;
using TaskManagement.Entities.DbSet;
using TaskManagement.Entities.Dtos.Incoming;
using TaskManagment.Dataservice.IConfiguration;

namespace TaskManagment.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.All();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUser", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            var _user = new User();
            _user.LastName = user.LastName;
            _user.FirstName = user.FirstName;
            _user.Email = user.Email;
            _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
            _user.Phone = user.Phone;
            _user.Country = user.Country;
            _user.Status = 1;

            _unitOfWork.Users.Add(_user);
            _unitOfWork.CompleteAsync();
            return CreatedAtRoute("GetUser", _user.Id, user); // return a 201
        }



    }
}