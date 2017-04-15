using Munazara.Application.Data.Reponses;
using Munazara.Application.Data.Requests;
using System.Collections.Generic;

namespace Munazara.Application.Data
{
    public interface ITopicService
    {
        int CreateTopic(CreateTopicRequest request);
        List<GetLastTopicsResponse> GetLastTopics();
    }
}