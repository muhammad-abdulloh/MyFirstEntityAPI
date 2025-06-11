using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstEntityAPI.Models.DTOS;
using MyFirstEntityAPI.Services.ComputerServices;

namespace MyFirstEntityAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputersController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComputers()
        {
            var result = await _computerService.GetComputersAsync();

            if (result == null)
            {
                return NotFound("Computerlar topilmadi");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdComputer(int id)
        {
            var result = await _computerService.GetByIdComputerAsync(id);

            if (result == null)
            {
                return NotFound("Computerlar topilmadi");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComputer(ComputerDTO compDTO)
        {
            var result = await _computerService.CreateAsync(compDTO);

            if (result == null)
            {
                return NotFound("Computerlar yaratilmadi");
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var result = await _computerService.DeleteAsync(id);

            if (result == false)
            {
                return NotFound("Computerlar o'chirilmadi yoki topilmadi");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComputer(int id, ComputerDTO compDTO)
        {
            var result = await _computerService.UpdateAsync(id, compDTO);

            if (result == null)
            {
                return NotFound("Computerlar topilmadi");
            }

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRAMComputer(int id, int Ram)
        {
            var result = await _computerService.UpdateRAMAsync(id, Ram);

            if (result == null)
            {
                return NotFound("Computerlar topilmadi");
            }

            return Ok(result);
        }
    }
}
