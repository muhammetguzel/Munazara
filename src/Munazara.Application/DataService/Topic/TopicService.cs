using Munazara.Application.DataService.Topic.Request;
using Munazara.Application.DataService.Topic.Response;
using Munazara.CrossCutting.General;
using Munazara.Data.Repository;
using Munazara.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System;

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
                CategorySlug = x.Category.Slug,
                CategoryName = x.Category.Name,
                CategoryColor = x.Category.Color,
                Id = x.Id,
                ReplyCount = x.ReplyCount,
                Slug = x.Slug,
                Title = x.Title,
                ViewCount = x.ViewCount
            }).ToList();
        }

        public GetTopicDetailResponse GetTopicDetail(int id)
        {
            return uow.Repository<Domain.Model.Topic>().GetBy(x => x.Id == id).Select(x => new GetTopicDetailResponse
            {
                CategorySlug = x.Category.Slug,
                CategoryName = x.Category.Name,
                CategoryColor = x.Category.Color,
                Id = x.Id,
                ReplyCount = x.ReplyCount,
                Slug = x.Slug,
                Title = x.Title,
                ViewCount = x.ViewCount,
                CreateDate = x.CreateDate,
                Posts = x.Posts.OrderBy(p => p.CreateDate).Select(p => new PostDetailDto
                {
                    Content = p.Content,
                    CreateDate = p.CreateDate,
                    Id = p.Id,
                    MemberAvatar = p.Member.Avatar,
                    MemberUserName = p.Member.UserName
                })
            }).FirstOrDefault();
        }
    }
}