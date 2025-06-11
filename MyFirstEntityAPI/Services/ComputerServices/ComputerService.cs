using Microsoft.EntityFrameworkCore;
using MyFirstEntityAPI.DATA;
using MyFirstEntityAPI.Models;
using MyFirstEntityAPI.Models.DTOS;

namespace MyFirstEntityAPI.Services.ComputerServices
{
    public class ComputerService : IComputerService
    {
        private readonly MyEntityDbContext _context;

        public ComputerService(MyEntityDbContext context)
        {
            _context = context;
        }

        public async Task<ComputerDTO> CreateAsync(ComputerDTO compDto)
        {
            var computer = new Computer()
            {
                Name = compDto.Name,
                BrandName = compDto.BrandName,
                Description = compDto.Description,
                RAM = compDto.RAM,
                GPU = compDto.GPU,
                HardDiskHDD = compDto.HardDiskHDD,
                HardDiskSSD = compDto.HardDiskSSD,
                CPU = compDto.CPU,
            };

            var result = await _context.Computers.AddAsync(computer);

            await _context.SaveChangesAsync();

            return compDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var result = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                _context.Computers.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Computer> GetByIdComputerAsync(int id)
        {
            var result = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<Computer>> GetComputersAsync()
        {
            var computers = await _context.Computers.ToListAsync();

            return computers;
        }

        public async Task<ComputerDTO> UpdateAsync(int id, ComputerDTO compDto)
        {
            var result  = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                result.Name = compDto.Name;
                result.BrandName = compDto.BrandName;
                result.Description = compDto.Description;
                result.RAM = compDto.RAM;
                result.GPU = compDto.GPU;
                result.HardDiskHDD = compDto.HardDiskHDD;
                result.HardDiskSSD = compDto.HardDiskSSD;
                result.CPU = compDto.CPU;

                await _context.SaveChangesAsync();

                return compDto;
            }

            return null;
        }

        public async Task<Computer> UpdateRAMAsync(int id, int RAM)
        {
            var result = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                result.RAM = RAM;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
