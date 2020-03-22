using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? PrevPostId { get; set; }
        public int? NextPostId { get; set; }
        public DateTime PublishDate { get; set; }
        public int BlogId { get; set; }
        public string Body { get; set; }
        public virtual Post PrevPost { get; set; }
        public virtual Post NextPost { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
    }
}