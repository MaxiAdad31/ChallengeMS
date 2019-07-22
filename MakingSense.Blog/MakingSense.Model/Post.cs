using MakingSense.Model.Helpers;
using Microsoft.AspNetCore.Identity;

namespace MakingSense.Model
{
    public class Post : IdentityUser, ISoftDeleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public bool Deleted { get; set; }
    }
}
