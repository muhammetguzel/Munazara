using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munazara.Application.DataService.Topic.Response
{
    public class GetTopicDetailResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Slug { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }

        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryColor { get; set; }

        public IEnumerable<PostDetailDto> Posts { get; set; }
    }

    public class PostDetailDto
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string MemberUserName { get; set; }
        public string MemberAvatar { get; set; }
    }
}