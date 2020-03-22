using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
    }
}