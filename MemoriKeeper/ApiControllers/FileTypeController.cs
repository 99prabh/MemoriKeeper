using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoriKeeper.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTypeController : ControllerBase
    {
        private readonly MemoriKeeperContext _dbContext;
        public FileTypeController(MemoriKeeperContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<FileType>>> GetFileTypes()
        {
            var fileTypes = await _dbContext.FileTypes.ToListAsync();
            return Ok(fileTypes);
        }
    }
}