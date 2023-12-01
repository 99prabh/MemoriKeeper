namespace MemoriKeeper.Model.Models
{
    public class Diaryentry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AttachmentId { get; set; }
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}