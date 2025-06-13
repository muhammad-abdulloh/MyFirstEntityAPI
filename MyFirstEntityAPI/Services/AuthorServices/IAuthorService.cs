using MyFirstEntityAPI.Models;
using MyFirstEntityAPI.Models.DTOS;

namespace MyFirstEntityAPI.Services.AuthorServices
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAll();
        public Task<Author> Create(AuthorDTO authodDTO);
    }
}
