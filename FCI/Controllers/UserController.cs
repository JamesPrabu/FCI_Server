using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Contract;

namespace FCI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user) { 
            this._user = user;
        
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllRecordes()
        {
            var response = this._user.GetAllRepo();
            return Ok(response);
        }

        [HttpGet("get")]
        public IActionResult GetSingleRecord(long id)
        {
            return Ok(this._user.GetSingleRepo(id));    
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            return Ok(this._user.AddUserRepo(user));

        }


        [HttpDelete]
        public IActionResult RemoveUser(long id)
        {
            return Ok(this._user.RemoveUser(id));

        }


        [HttpPut("edit")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(this._user.UpdateUserRepo(user));

        }

    }
}
