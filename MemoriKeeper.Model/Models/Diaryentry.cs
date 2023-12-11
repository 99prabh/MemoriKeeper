using System.ComponentModel.DataAnnotations;

namespace MemoriKeeper.Model.Models
{
    public class Diaryentry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied title.")]
        [StringLength(300, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, select attachment file")]
        public int AttachmentId { get; set; }

        [Required(ErrorMessage = "Please, provied description of this attachment.")]
        [StringLength(1500, MinimumLength = 2)]
        public string Description { get; set; }

        public string? ApplicationUserId { get; set; }

        public Attachment Attachment { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}