using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.FileIO;

namespace MemoriKeeper.Model.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, select type.")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Please, provied file path.")]
        [StringLength(500, MinimumLength = 2)]
        public string FilePath { get; set; }
        public string Description { get; set; }

        public virtual FileType FileType { get; set; }
    }
}