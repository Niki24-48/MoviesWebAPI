using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Context;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenereController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        public GenereController(MoviesDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genere>>> GetGeneres()
        {
            return await _context.Genres.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genere>> GetGenreByID(string id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPost]
        public async Task<ActionResult<Genere>> PostGenres(Genere genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Genere>> PutGenre(Genere genre , string id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            _context.Update(genre);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("({id})")]
        public async Task<ActionResult<Genere>> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
