using System.ComponentModel;

namespace Munazara.Application.Data.Requests
{
    public class CreateTopicRequest
    {

      
        public int CategoryId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}