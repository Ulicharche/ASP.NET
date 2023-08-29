using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;



    namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class BooksController : ControllerBase
    {
        [HttpGet()]
        public ActionResult <Book> GetBook(int? index)
        { 
            try
            {
                if (index == null)
                {
                    return Ok(StaticDb.ListBooks);
                }
                if(index<0)
                {
                    return BadRequest("Indeksot e so negativna vrednost!");
                }
                if (index>= StaticDb.ListBooks.Count())
                {
                    return NotFound($"Ne go najdovme indeksot {index}");
                }
                return Ok(StaticDb.ListBooks[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("filterBooks")]
        public ActionResult<Book> FilterBooks(string? author, string? title)
        {
            try
            {
                if(string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
                {
                    return BadRequest("Vnesete gi potrebnite podatoci");
                }
                return Ok(StaticDb.ListBooks.FirstOrDefault(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpPost] 
        public IActionResult AddNewBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Dodajte naslov i avtor na knigata!");
                }
                StaticDb.ListBooks.Add(book);
                return StatusCode(StatusCodes.Status201Created, $"Knigata {book.Author} od {book.Title}e dodadena");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpPost("listOfBooks")]
        public ActionResult<List<string>> ListOfBooks([FromBody]List<Book>Books) 
        {
            if (!Books.Any())
            {
                return BadRequest("Pratete ni lista od knigi");
            }

            List<string> result = new List<string>();
            foreach (Book book in Books)
            {
                result.Add(book.Title);
            }
            return Ok(result);  
        }
    }
}
