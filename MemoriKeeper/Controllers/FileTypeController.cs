using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace MemoriKeeper.Controllers
{
    public class FileTypeController : Controller
    {
        private readonly MemoriKeeperContext _dbContext;

        public FileTypeController(MemoriKeeperContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: FileTypeController
        [HttpGet]
        public async Task<ActionResult<ICollection<FileType>>> Index()
        {
            var getFileTypes = await _dbContext.FileTypes.ToListAsync();
            return View(getFileTypes);
        }
    }
}