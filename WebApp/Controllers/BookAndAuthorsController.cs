using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class BookAndAuthorsController : Controller
    {
        private readonly AppDbContext _context;

        public BookAndAuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookAndAuthors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BookAndAuthors.Include(b => b.Author).Include(b => b.Book);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BookAndAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndAuthor = await _context.BookAndAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndAuthor == null)
            {
                return NotFound();
            }

            return View(bookAndAuthor);
        }

        // GET: BookAndAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            return View();
        }

        // POST: BookAndAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,AuthorId,Id")] BookAndAuthor bookAndAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAndAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", bookAndAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndAuthor.BookId);
            return View(bookAndAuthor);
        }

        // GET: BookAndAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndAuthor = await _context.BookAndAuthors.FindAsync(id);
            if (bookAndAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", bookAndAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndAuthor.BookId);
            return View(bookAndAuthor);
        }

        // POST: BookAndAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,AuthorId,Id")] BookAndAuthor bookAndAuthor)
        {
            if (id != bookAndAuthor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAndAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAndAuthorExists(bookAndAuthor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", bookAndAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookAndAuthor.BookId);
            return View(bookAndAuthor);
        }

        // GET: BookAndAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookAndAuthor = await _context.BookAndAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookAndAuthor == null)
            {
                return NotFound();
            }

            return View(bookAndAuthor);
        }

        // POST: BookAndAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookAndAuthor = await _context.BookAndAuthors.FindAsync(id);
            _context.BookAndAuthors.Remove(bookAndAuthor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAndAuthorExists(int id)
        {
            return _context.BookAndAuthors.Any(e => e.Id == id);
        }
    }
}
