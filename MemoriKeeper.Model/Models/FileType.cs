using System.ComponentModel.DataAnnotations;

namespace MemoriKeeper.Model.Models
{
    public class FileType
    {
        public FileType()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied type name.")]
        [StringLength(50, MinimumLength = 2)]
        public string TypeName { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }
}