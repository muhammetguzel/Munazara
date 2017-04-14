using System;
using System.Collections.Generic;

namespace Munazara.Domain.Model
{
    public class Member
    {
        public Member()
        {
            CreateDate = DateTime.UtcNow;
            Type = MemberType.Standart;
            IsActive = false;
            IsBanned = false;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public MemberType Type { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

    public enum MemberType
    {
        Standart,
        Editor,
        Admin
    }
}