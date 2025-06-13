using Microsoft.EntityFrameworkCore;
using MyFirstEntityAPI.DATA;
using MyFirstEntityAPI.Models;
using MyFirstEntityAPI.Models.DTOS;

namespace MyFirstEntityAPI.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly MyEntityDbContext _context;

        public AuthorService(MyEntityDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Create(AuthorDTO authodDTO)
        {
            var author = new Author()
            {
                Name = authodDTO.Name,
                BirthDate = authodDTO.BirthDate,
                PhoneNumber = authodDTO.PhoneNumber,
                Email = authodDTO.Email,
            };

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var result = await _context.Authors.Include(x => x.Books).ToListAsync();

            return result;
        }
    }
}
