using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.Controllers
{
    public class FileTypeController : Controller
    {
        private readonly MemoriKeeperContext _dbContext;
        public FileTypeController(MemoriKeeperContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<FileType>>> Index()
        {
            var getFileTypes = await _dbContext.FileTypes.ToListAsync();
            return View(getFileTypes);
        }
    }
}