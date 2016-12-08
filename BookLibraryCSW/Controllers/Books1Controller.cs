using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookLibraryCSW.Models;

namespace BookLibraryCSW.Controllers
{
    public class Books1Controller : ApiController
    {
        private BookLibraryCSWContext db = new BookLibraryCSWContext();

        
        /// <summary>
        /// GET: Return all books
        /// </summary>
        /// <returns></returns>
        public IQueryable<Books> GetBooks()
        {
            return db.Books;
        }

        /// <summary>
        /// GET: Return all books by category
        /// </summary>
        /// <param name="idCategory">id of the category</param>
        /// <returns></returns>
        public IQueryable<Books> GetBooksByCat(int idCategory)
        {
            return db.Books.Where(x => x.idCategory.Equals(idCategory));
        }

        /// <summary>
        /// GET: Return all books by author
        /// </summary>
        /// <param name="idAuthor">id of the category</param>
        /// <returns></returns>
        public IQueryable<Books> GetBooksByAuthor(int idAuthor)
        {
            return db.Books.Where(x => x.idAuthor.Equals(idAuthor));
        }        

        // GET: api/Books1/5
        [ResponseType(typeof(Books))]
        public async Task<IHttpActionResult> GetBooks(int id)
        {
            Books books = await db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // PUT: api/Books1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBooks(int id, Books books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != books.Id)
            {
                return BadRequest();
            }

            db.Entry(books).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books1
        [ResponseType(typeof(Books))]
        public async Task<IHttpActionResult> PostBooks(Books books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(books);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = books.Id }, books);
        }

        // DELETE: api/Books1/5
        [ResponseType(typeof(Books))]
        public async Task<IHttpActionResult> DeleteBooks(int id)
        {
            Books books = await db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            db.Books.Remove(books);
            await db.SaveChangesAsync();

            return Ok(books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BooksExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}