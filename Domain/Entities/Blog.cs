using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
