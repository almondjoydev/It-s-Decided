using ItsDecidedDemo.Data;
using ItsDecidedDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ItsDecidedDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PollController : ControllerBase
{
    private IDDbContext _dbContext;
    public PollController(IDDbContext context)
    {
        _dbContext = context;
    }
    // created a private field so it's only accessible/ editable within the class itself
    // next used a constructor that basically states whenever this class is called, our database will be instanced in it's current state as our editable _dbcontext

    [HttpGet]
    public IActionResult GetPolls()
    {
       return Ok(_dbContext.Polls.Include(p => p.PollType)); 
    }
    // your run of the mill get endpoint, noted by the HttpGet attribute. This is a function that returns and IActionResult. Think back to Results.Ok(), .NotFound(), etc... 

    [HttpGet("{id}")]
    public IActionResult GetPollById(int id)
    {
        Poll found = _dbContext.Polls
        .Include(p => p.PollType)
        .SingleOrDefault(p => p.Id == id);

        if (found == null)
        {
            return NotFound();
        }
        return Ok(found);
    }
}