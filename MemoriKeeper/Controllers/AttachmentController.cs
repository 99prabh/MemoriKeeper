using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;
using MemoriKeeper.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.Controllers
{
    public class AttachmentController : Controller
    {
        private readonly MemoriKeeperContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AttachmentController(MemoriKeeperContext dbContext, IWebHostEnvironment? webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<MemoriKeeper.Model.Models.Attachment>> Index()
        {
            var attachments = await _dbContext.Attachments.Include(a => a.FileType).ToListAsync();
            return View(attachments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetFileTypes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile filePath, AttachmentCreateModel attachmentModel)
        {
            attachmentModel.FilePath = await UploadFile(filePath);

            var attachment = new Model.Models.Attachment()
            {
                Title = attachmentModel.Title,
                FileTypeId = attachmentModel.FileTypeId,
                FilePath = attachmentModel.FilePath,
            };

            _dbContext.Attachments.Add(attachment);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var existAttachment = await _dbContext.Attachments
                                  .Include(a => a.FileType)
                                  .Where(a => a.Id == id)
                                  .FirstOrDefaultAsync();

            if (existAttachment is null)
                return BadRequest();

            await GetFileTypes();
            return View(existAttachment);
        }

        [HttpPost]
        public async Task<IActionResult> Details(IFormFile filePath, Attachment attachmentModel)
        {
            attachmentModel.FilePath = await UploadFile(filePath);

            _dbContext.Attachments.Update(attachmentModel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var existAttachment = await _dbContext.Attachments.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (existAttachment is null)
                return BadRequest();

            _dbContext.Attachments.Remove(existAttachment);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task GetFileTypes()
        {
            ViewBag.FileTypes = await _dbContext.FileTypes.Select(s => new SelectListModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
        }

        public async Task<string> UploadFile(IFormFile filePath)
        {
            if (filePath != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, @"wwwroot\upload_images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + filePath.FileName;
                string fullFilePath = Path.Combine(uploadsFolder, uniqueFileName);
                await filePath.CopyToAsync(new FileStream(fullFilePath, FileMode.Create));

                return uniqueFileName;
            }

            return "no_images.jpg";
        }
    }
}