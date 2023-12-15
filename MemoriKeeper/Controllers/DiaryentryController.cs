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
		public async Task<ActionResult> Index(string searchKeyword)
		{
			if(string.IsNullOrEmpty(searchKeyword))
			{
                var diaryentries = await _dbContext.Diaryentries
                               .Include(d => d.Attachment)
                               .Where(d => !d.IsDeleted)
                               .ToListAsync();

                return View(diaryentries);
            }
			else
			{
				var search = await _dbContext.Diaryentries
                               .Include(d => d.Attachment)
                               .Where(d => !d.IsDeleted
									  && (d.Title.ToLower().Contains(searchKeyword.ToLower())
                                      || d.Description.ToLower().Contains(searchKeyword.ToLower())))
                               .ToListAsync();

                return View(search);
            }
		}

        [HttpGet]
        public async Task<ActionResult<MemoriKeeper.Model.Models.Diaryentry>> DeletedHistory()
        {
            var diaryentries = await _dbContext.Diaryentries
                               .Include(d => d.Attachment)
                               .Where(d => d.IsDeleted)
                               .ToListAsync();

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
			diaryentryModel.CreatedDateTime = DateTime.Now;
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

			existDiaryentry.IsDeleted = true;
			existDiaryentry.DeletedDateTime = DateTime.Now;

			_dbContext.Diaryentries.Update(existDiaryentry);
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
