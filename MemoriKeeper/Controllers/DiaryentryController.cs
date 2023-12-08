using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using MemoriKeeper.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.Controllers
{
    public class DiaryentryController : Controller
    {
        private readonly MemoriKeeperContext _dbContext;
        public DiaryentryController(MemoriKeeperContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<MemoriKeeper.Model.Models.Diaryentry>> Index()
        {
            var diaryentries = await _dbContext.Diaryentries.Include(d => d.Attachment).ToListAsync();
            return View(diaryentries);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetAttachments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Diaryentry diaryentryModel)
        {
            _dbContext.Diaryentries.Add(diaryentryModel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var existDiaryentrY = await _dbContext.Diaryentries
                                  .Include(a => a.Attachment)
                                  .Where(a => a.Id == id)
                                  .FirstOrDefaultAsync();

            if (existDiaryentrY is null)
                return BadRequest();

            await GetAttachments();
            return View(existDiaryentrY);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Diaryentry diaryentryModel)
        {
            _dbContext.Diaryentries.Update(diaryentryModel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var existDiaryentry = await _dbContext.Diaryentries.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existDiaryentry is null)
                return BadRequest();

            _dbContext.Diaryentries.Remove(existDiaryentry);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task GetAttachments()
        {
            ViewBag.Attachments = await _dbContext.Attachments.Select(s => new SelectListModel
            {
                Id = s.Id,
                Name = s.Title
            }).ToListAsync();
        }
    }
}