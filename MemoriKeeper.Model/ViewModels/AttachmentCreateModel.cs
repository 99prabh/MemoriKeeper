using System.ComponentModel.DataAnnotations;

namespace MemoriKeeper.Model.ViewModels
{
    public class AttachmentCreateModel
    {
        [Required(ErrorMessage = "Please, select type.")]
        public int FileTypeId { get; set; }

        [Required(ErrorMessage = "Please, provied file path.")]
        [StringLength(500, MinimumLength = 2)]
        public string FilePath { get; set; }

        public string Description { get; set; }
    }
}