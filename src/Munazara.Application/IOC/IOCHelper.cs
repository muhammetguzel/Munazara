using Autofac;

using Munazara.Application.DataService.Category;
using Munazara.Application.DataService.Member;
using Munazara.Application.DataService.Topic;
using Munazara.Data.Repository;

namespace Munazara.Application.IOC
{
    public static class IOCHelper
    {
        public static ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TopicService>().As<ITopicService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<MemberService>().As<IMemberService>();
            return builder;
        }
    }
}