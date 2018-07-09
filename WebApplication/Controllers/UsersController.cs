using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;
using WebApplication.Models;
using WebApplication.Services;

namespace HelloAngularApp.Controllers
{
  [Route("api/users")]
  public class UsersController : Controller
  {
    UserService _userService;
    public UsersController(ApplicationContext context)
    {
      _userService = new UserService(context);
    }

    [HttpPost]
    public IActionResult Authorize([FromBody]Users user)
    {
      if (ModelState.IsValid)
      {
        var isAuth = _userService.Authorize(user.Name, user.Password);
        return Ok(isAuth);
      }
      return BadRequest(ModelState);
    }

    [HttpPost]
    public IActionResult Registrate([FromBody]Users user)
    {
      if (ModelState.IsValid)
      {
        _userService.Register(user.Name, user.Password);
        return Ok();
      }
      return BadRequest(ModelState);
    }
  }
}