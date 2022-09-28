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
    public class PublisherController : ControllerBase
    {
        public PublishersService _PublishersService;

        public PublisherController(PublishersService PublishersService)
        {
            _PublishersService = PublishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var allpubishers = _PublishersService.GetAllPublishers();
            return Ok(allpubishers);
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _PublishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-books&authors-by-id/{id}")]
        public IActionResult GetPublisherBooksAndAuthorsById(int id)
        {
            var publisher = _PublishersService.GetPublisherBooksAndAuthorsById(id);
            return Ok(publisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _PublishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}

