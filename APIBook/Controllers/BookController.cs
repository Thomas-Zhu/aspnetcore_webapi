using APIBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        public BookController(BookContext context)
        {
            _context = context;
        }
        //GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            return _context.Books.Select(x => BookToDTO(x)).ToList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            var bookInfo = _context.Books.Find(id);
            if (bookInfo == null)
            {
                return NotFound();
            }
            return BookToDTO(bookInfo);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id=book.Id},book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            var bookInfo = _context.Books.Find(id);
            if (bookInfo == null)
            {
                return NoContent();
            }
            bookInfo.Title = book.Title;
            bookInfo.Author = book.Author;
            bookInfo.PublicationDate = book.PublicationDate;
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, bookInfo);
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookInfo = _context.Books.Find(id);
            if (bookInfo == null)
            {
                return NoContent();
            }
            _context.Books.Remove(bookInfo);
            _context.SaveChanges();
            return NoContent();
        }
        private static BookDTO BookToDTO(Book book) =>
            new BookDTO
            {
                Id=book.Id,
                Title=book.Title,
                PublicationDate=book.PublicationDate
            };
    }
}
