using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAndAuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookAndAuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookAndAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAndAuthor>>> GetBookAndAuthors()
        {
            return await _context.BookAndAuthors.ToListAsync();
        }

        // GET: api/BookAndAuthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookAndAuthor>> GetBookAndAuthor(int id)
        {
            var bookAndAuthor = await _context.BookAndAuthors.FindAsync(id);

            if (bookAndAuthor == null)
            {
                return NotFound();
            }

            return bookAndAuthor;
        }

        // PUT: api/BookAndAuthors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAndAuthor(int id, BookAndAuthor bookAndAuthor)
        {
            if (id != bookAndAuthor.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookAndAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAndAuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookAndAuthors
        [HttpPost]
        public async Task<ActionResult<BookAndAuthor>> PostBookAndAuthor(BookAndAuthor bookAndAuthor)
        {
            _context.BookAndAuthors.Add(bookAndAuthor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookAndAuthor", new { id = bookAndAuthor.Id }, bookAndAuthor);
        }

        // DELETE: api/BookAndAuthors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookAndAuthor>> DeleteBookAndAuthor(int id)
        {
            var bookAndAuthor = await _context.BookAndAuthors.FindAsync(id);
            if (bookAndAuthor == null)
            {
                return NotFound();
            }

            _context.BookAndAuthors.Remove(bookAndAuthor);
            await _context.SaveChangesAsync();

            return bookAndAuthor;
        }

        private bool BookAndAuthorExists(int id)
        {
            return _context.BookAndAuthors.Any(e => e.Id == id);
        }
    }
}
