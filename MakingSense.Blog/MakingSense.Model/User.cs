using MakingSense.Model.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MakingSense.Model
{
    public class User : IdentityUser, ISoftDeleted
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Post> Posts { get; set; }
        public bool Deleted { get; set; }
    }
}
