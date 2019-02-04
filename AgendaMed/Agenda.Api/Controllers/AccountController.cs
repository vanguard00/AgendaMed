using Agenda.Api.Models;
using Agenda.Domain.Account.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserServices _userServices;
        public AccountController(UserServices userServices)
        {
            _userServices = userServices;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userServices.Create(user.Username, user.Password, user.Name);
        }
    }
}