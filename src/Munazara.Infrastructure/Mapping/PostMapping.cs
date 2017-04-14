using Munazara.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munazara.Data.Mapping
{
    public class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Content).HasColumnType("nvarchar(max)");
            this.Property(x => x.CreateDate).HasColumnType("smalldatetime").IsRequired();
        }
    }
}