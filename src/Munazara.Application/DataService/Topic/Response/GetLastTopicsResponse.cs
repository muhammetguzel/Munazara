namespace Munazara.Application.DataService.Topic.Response
{
    public class GetLastTopicsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public CategorySlugNameColor Category { get; set; }

        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }
    }
}