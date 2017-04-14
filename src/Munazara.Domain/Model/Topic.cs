﻿using System;
using System.Collections.Generic;

namespace Munazara.Domain.Model
{
    public class Topic
    {
        public Topic(Post post)
        {
            ReplyCount = 0;
            ViewCount = 0;
            
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Slug { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
        public int CategoryId { get; set; }
        public int MemberId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public void AddPost(Post post)
        {
            this.Posts.Add(post);
            if (this.Posts.Count > 1)
            {
                ReplyCount++;
            }
        }

       
    }
}