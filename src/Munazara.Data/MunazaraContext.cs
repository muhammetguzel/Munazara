using Munazara.Data.Mapping;
using Munazara.Domain.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Munazara.Data
{
    public class MunazaraContext : DbContext
    {
        public MunazaraContext() : base("MunazaraContext")
        {
            Database.SetInitializer<MunazaraContext>(null);
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new TopicMapping());
            modelBuilder.Configurations.Add(new PostMapping());
            modelBuilder.Configurations.Add(new MemberMapping());
        }
    }
}