namespace Munazara.Application.DataService.Topic.Response
{
    public class GetLastTopicsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryColor { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
    }
}