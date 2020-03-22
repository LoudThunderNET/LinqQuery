using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PostComment
    {
        public PostComment()
        {
            Comments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int ParentCommentId { get; set; }
        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
        public virtual PostComment ParentComment { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }
    }
}
