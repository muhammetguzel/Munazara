using Munazara.Application.Data.Requests;
using Munazara.CrossCutting.General;
using Munazara.Data.Repository;
using Munazara.Domain.Model;

namespace Munazara.Application.Data
{
    public class TopicService : ITopicService
    {
        private IUnitOfWork uow;

        public TopicService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateTopic(CreateTopicRequest request)
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
        }
    }
}