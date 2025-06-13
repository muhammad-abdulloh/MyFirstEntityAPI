using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstEntityAPI.DATA;
using MyFirstEntityAPI.Models;
using MyFirstEntityAPI.Models.DTOS;
using MyFirstEntityAPI.Services.AuthorServices;

namespace MyFirstEntityAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly MyEntityDbContext _context;
        public AuthorsController(IAuthorService service, MyEntityDbContext context)
        {
            _authorService = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorDTO authorDTO)
        {
            var result = await _authorService.Create(authorDTO);

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _authorService.GetAll();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDTO bookDTO)
        {
            var book = new Book()
            {
                Title = bookDTO.Title,
                Name = bookDTO.Name,
                Description = bookDTO.Description,
                PublishedDate = bookDTO.PublishedDate,
                AuthorId = bookDTO.AuthorId,
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return Ok("Kitob yaratildi");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _context.Books.ToListAsync();

            return Ok(result);
        }
    }
}
