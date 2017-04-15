using Munazara.Application.DataService.Topic.Request;
using Munazara.Application.DataService.Topic.Response;
using Munazara.CrossCutting.General;
using Munazara.Data.Repository;
using Munazara.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Munazara.Application.DataService.Topic
{
    public class TopicService : ITopicService
    {
        private IUnitOfWork uow;

        public TopicService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public CreateTopicResponse CreateTopic(CreateTopicRequest request)
        {
            Domain.Model.Topic topic = new Domain.Model.Topic()
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
            uow.Repository<Domain.Model.Topic>().Add(topic);
            uow.SaveChanges();

            return new CreateTopicResponse()
            {
                Id = topic.Id,
                Slug = topic.Slug
            };
        }

        public List<GetLastTopicsResponse> GetLastTopics()
        {
            return uow.Repository<Domain.Model.Topic>().All().OrderByDescending(x => x.CreateDate).Select(x => new GetLastTopicsResponse
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