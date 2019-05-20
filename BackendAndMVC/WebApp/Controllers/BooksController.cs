using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using ee.itcollege.akaver.Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string search)
        {
            ViewBag.search = search;
            
            var query = 
                _context.Books
                    .Include(b => b.AppUser)
                    .Include(b => b.Publisher)
                    .Include(b => b.BookAndAuthors)
                    .ThenInclude(a => a.Author)
                    .Include(b => b.Comments)
                    .Where(b => b.AppUserId == User.GetUserId())
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToUpper().Trim();
                query = query
                    .Where(b => 
                        b.Title.ToUpper().Contains(search) || 
                        b.Publisher.PublisherName.ToUpper().Contains(search) || 
                        b.BookAndAuthors.Any(a => 
                            a.Author.FirstName.ToUpper().Contains(search) || 
                            a.Author.LastName.ToUpper().Contains(search)));
                
            }

            
            
            return View(await query.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.AppUser)
                .Include(b => b.Publisher)
                .Include(b => b.BookAndAuthors)
                .ThenInclude(a => a.Author)
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", nameof(Publisher.PublisherName));
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", nameof(Author.FirstLastName));

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateVM vm)
        {
            vm.Book.AppUserId = User.GetUserId();
            
            if (ModelState.IsValid)
            {
                
                _context.Add(vm.Book);

                _context.BookAndAuthors.Add(new BookAndAuthor()
                {
                    Book = vm.Book,
                    AuthorId = vm.AuthorId
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", nameof(Author.FirstLastName), vm.AuthorId);

            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", vm.Book.PublisherId);
            return View(vm);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", book.AppUserId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,PublishingYear,PublisherId,AppUserId,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", book.AppUserId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.AppUser)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
