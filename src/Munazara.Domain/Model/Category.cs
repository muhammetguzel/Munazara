using System;
using System.Collections.Generic;

namespace Munazara.Domain.Model
{
    public class Category
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Color { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}