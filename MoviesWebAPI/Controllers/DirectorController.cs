using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Context;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public DirectorController(MoviesDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirectorById(string id)
        {
            var director = await _context.Directors.FindAsync(id);
            if(director == null)
            {
                return NotFound();
            }
            return director;
        }

        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(Director director)
        {
            if(director != null)
            {
                _context.Directors.Add(director);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Director>> PutDirector(Director director , string id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            _context.Update(director);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteDirector(string id)
        {
            var director = await _context.Directors.FindAsync(id);
            if(director == null)
            {
                return NotFound();
            }
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
