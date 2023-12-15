using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryentryApiController : ControllerBase
    {
        private readonly MemoriKeeperContext _dbContext;
        public DiaryentryApiController(MemoriKeeperContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<Diaryentry>>> GetDiaryentries()
        {
            var diaryentries = await _dbContext.Diaryentries
                              .Include(a => a.Attachment)
                              .Where(d => !d.IsDeleted)
                              .ToListAsync();

            return Ok(diaryentries);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Diaryentry>>> GetDeletedDiaryentries()
        {
            var diaryentries = await _dbContext.Diaryentries
                              .Include(a => a.Attachment)
                              .Where(d => d.IsDeleted)
                              .ToListAsync();

            return Ok(diaryentries);
        }

        [HttpGet]
        public async Task<ActionResult<Diaryentry>> GetDiaryentry(int id)
        {
            if (id == 0)
                return BadRequest();

            var existDiaryentry = await _dbContext.Diaryentries.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existDiaryentry == null)
                return BadRequest();

            return Ok(existDiaryentry);
        }

        [HttpPost]
        public async Task<ActionResult<Diaryentry>> Create(Diaryentry diaryentryModel)
        {
            diaryentryModel.CreatedDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                _dbContext.Diaryentries.Add(diaryentryModel);
                await _dbContext.SaveChangesAsync();

                return Ok(diaryentryModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Diaryentry>> Update(Diaryentry diaryentryModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Diaryentries.Update(diaryentryModel);
                await _dbContext.SaveChangesAsync();

                return Ok(diaryentryModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var existDiaryentry = await _dbContext.Diaryentries.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existDiaryentry == null)
                return BadRequest();

            existDiaryentry.IsDeleted = true;
            existDiaryentry.DeletedDateTime = DateTime.Now;
            _dbContext.Diaryentries.Update(existDiaryentry);
            await _dbContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}
