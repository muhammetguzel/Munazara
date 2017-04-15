using Munazara.Application.Data.Reponses;
using Munazara.Application.Data.Requests;
using Munazara.CrossCutting.General;
using Munazara.Data.Repository;
using Munazara.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Munazara.Application.Data
{
    public class TopicService : ITopicService
    {
        private IUnitOfWork uow;

        public TopicService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public int CreateTopic(CreateTopicRequest request)
        {
            Topic topic = new Topic()
            {
                CategoryId = request.CategoryId,
                MemberId = request.MemberId,
                Slug = SlugHelper.CreateSlug(request.Title),
                Title = request.Title,
            };

            topic.AddPost(new Post
            {
                Content = request.Content,
                MemberId = request.MemberId,
            });
            uow.Repository<Topic>().Add(topic);
            uow.SaveChanges();

            return topic.Id;
        }

        public List<GetLastTopicsResponse> GetLastTopics()
        {
            return uow.Repository<Topic>().All().OrderByDescending(x=>x.CreateDate).Select(x => new GetLastTopicsResponse
            {
                Category = new CategorySlugNameColor
                {
                    slug = x.Category.Slug,
                    Name = x.Category.Name,
                    Color = x.Category.Color
                },
                Id = x.Id,
                ReplyCount = x.ReplyCount,
                Slug = x.Slug,
                Title = x.Title,
                ViewCount = x.ViewCount
            }).ToList();
        }
    }
}