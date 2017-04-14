using Autofac;
using Munazara.Application.Data;
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
            return builder;
        }
    }
}