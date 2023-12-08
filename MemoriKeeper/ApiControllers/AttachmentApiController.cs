using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoriKeeper.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentApiController : ControllerBase
    {
        private readonly MemoriKeeperContext _dbContext;
        public AttachmentApiController(MemoriKeeperContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<ICollection<Attachment>>> GetAttachments()
        {
            var attachments = await _dbContext.Attachments.Include(a => a.FileType).ToListAsync();
            return Ok(attachments);
        }

        [HttpGet]
        public async Task<ActionResult<Attachment>> GetAttachment(int id)
        {
            if (id == 0)
                return BadRequest();

            var existAttachment = await _dbContext.Attachments.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existAttachment == null)
                return BadRequest();

            return Ok(existAttachment);
        }

        [HttpPost]
        public async Task<ActionResult<Attachment>> Create(Attachment attachmentModel)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Attachments.Add(attachmentModel);
                await _dbContext.SaveChangesAsync();

                return Ok(attachmentModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Attachment>> Update(Attachment attachmentModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Attachments.Update(attachmentModel);
                await _dbContext.SaveChangesAsync();

                return Ok(attachmentModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var existAttachment = await _dbContext.Attachments.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existAttachment == null)
                return BadRequest();

            _dbContext.Attachments.Remove(existAttachment);
            await _dbContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}