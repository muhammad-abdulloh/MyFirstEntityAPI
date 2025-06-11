using MyFirstEntityAPI.Models;
using MyFirstEntityAPI.Models.DTOS;

namespace MyFirstEntityAPI.Services.ComputerServices
{
    public interface IComputerService
    {
        public Task<IEnumerable<Computer>> GetComputersAsync();
        public Task<Computer> GetByIdComputerAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<ComputerDTO> CreateAsync(ComputerDTO compDto);
        public Task<ComputerDTO> UpdateAsync(int id,  ComputerDTO compDto);
        public Task<Computer> UpdateRAMAsync(int id,  int RAM);
    }
}
