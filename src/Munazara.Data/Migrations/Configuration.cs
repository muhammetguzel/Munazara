namespace Munazara.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Munazara.Data.MunazaraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Munazara.Data.MunazaraContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Member.AddOrUpdate(new Domain.Model.Member { Email = "admin@yoursite.com", Password = "D033E22AE348AEB5660FC2140AEC35850C4DA997", Type = Domain.Model.MemberType.Admin, UserName = "admin" });
        }
    }
}