using Munazara.Application.Data.Requests;

namespace Munazara.Application.Data
{
    public interface ITopicService
    {
        void CreateTopic(CreateTopicRequest request);
    }
}