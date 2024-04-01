using ItsDecidedDemo.Data;
using ItsDecidedDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ItsDecidedDemo.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PollTypeController : ControllerBase
{
    private IDDbContext _dbContext;
    public PollTypeController(IDDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult getTypes()
    {
        return Ok(_dbContext.PollTypes);
    }

    [HttpGet("{id}")]
    public IActionResult getTypeById(int id)
    {
        PollType found = _dbContext.PollTypes.SingleOrDefault(pt => pt.Id == id);
        if (found == null) 
        { 
            return NotFound(); 
        }
        return Ok(found);    
    }
}