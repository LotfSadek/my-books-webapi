using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _AuthorsService;

        public AuthorsController(AuthorsService AuthorsService)
        {
            _AuthorsService = AuthorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthors([FromBody] AuthorVM author)
        {
            _AuthorsService.AddAuthor(author);
            return Ok(  );
        }

        [HttpGet("get-author-books-by-id/{id}")]
        public IActionResult GetAuthorsBooksById(int id)
        {
            var book = _AuthorsService.GetAuthorsBookById(id);
            return Ok(book);
        }
    }
   
}
