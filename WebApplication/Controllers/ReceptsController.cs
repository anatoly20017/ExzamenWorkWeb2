using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;
using WebApplication.Services;

namespace HelloAngularApp.Controllers
{
  [Route("api/products")]
  public class ReceptsController : Controller
  {
    ReceptService _receptService;

    public ReceptsController(ApplicationContext context)
    {
      _receptService = new ReceptService(context);
    }

    [HttpGet]
    public IEnumerable<Recept> GetRecepts()
    {
      return _receptService.GetAllRecepts();
    }

    [HttpPost]
    public IActionResult AddRecept([FromBody]Recept recept)
    {
      if (ModelState.IsValid)
      {
        _receptService.CreateRecept(recept);
        return Ok(recept);
      }
      return BadRequest(ModelState);
    }

    [HttpPut]
    public IActionResult Update([FromBody]Recept recept)
    {
      if (ModelState.IsValid)
      {
        _receptService.UpdateRecepts(recept);
        return Ok(recept);
      }
      return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{name}/{author}")]
    public IActionResult Delete(string name, string author)
    {
      _receptService.DeleteRecept(name, author);
      return Ok();
    }
  }
}