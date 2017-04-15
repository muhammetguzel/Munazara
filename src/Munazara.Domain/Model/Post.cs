using System;

namespace Munazara.Domain.Model
{
    public class Post
    {
        public Post()
        {
            CreateDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int MemberId { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Member Member { get; set; }
    }
}