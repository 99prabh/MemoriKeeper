using Microsoft.AspNetCore.Identity;

namespace MemoriKeeper.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Diaryentries = new HashSet<Diaryentry>();
        }

        public string? City { get; set; }

        public ICollection<Diaryentry> Diaryentries { get; set; }
    }   
}