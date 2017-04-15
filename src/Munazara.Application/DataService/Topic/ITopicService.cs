using Munazara.Application.DataService.Topic.Request;
using Munazara.Application.DataService.Topic.Response;
using System.Collections.Generic;

namespace Munazara.Application.DataService.Topic
{
    public interface ITopicService
    {
        CreateTopicResponse CreateTopic(CreateTopicRequest request);

        List<GetLastTopicsResponse> GetLastTopics();

        GetTopicDetailResponse GetTopicDetail(int id);
    }
}