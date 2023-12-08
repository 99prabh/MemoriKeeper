using System.ComponentModel.DataAnnotations;

namespace MemoriKeeper.Model.Models
{
    public class Attachment
    {
        public Attachment()
        {
            Diaryentries = new HashSet<Diaryentry>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied title.")]
        [StringLength(300, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, select type.")]
        public int FileTypeId { get; set; }

        [Required(ErrorMessage = "Please, provied file path.")]
        [StringLength(500, MinimumLength = 2)]
        public string FilePath { get; set; }

        public FileType FileType { get; set; }
        public ICollection<Diaryentry> Diaryentries { get; set; }
    }
}