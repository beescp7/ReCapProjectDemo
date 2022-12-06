using Business.Absract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {    //Loosely coupled
        //IoC container -- inversion of control
        IUsersServise _usersServise;

        public UsersController(IUsersServise usersServise)
        {
            _usersServise = usersServise;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _usersServise.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _usersServise.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _usersServise.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _usersServise.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
