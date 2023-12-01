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

        [Required(ErrorMessage = "Please, select type.")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Please, provied file path.")]
        [StringLength(500, MinimumLength = 2)]
        public string FilePath { get; set; }
        public string Description { get; set; }

        public virtual FileType FileType { get; set; }
        public virtual ICollection<Diaryentry> Diaryentries { get; set; }
    }
}