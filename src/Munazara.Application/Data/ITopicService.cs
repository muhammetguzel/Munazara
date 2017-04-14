using Munazara.Application.Data.Requests;

namespace Munazara.Application.Data
{
    public interface ITopicService
    {
        int CreateTopic(CreateTopicRequest request);
    }
}