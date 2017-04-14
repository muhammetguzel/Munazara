using Munazara.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munazara.Data.Mapping
{
    public class TopicMapping : EntityTypeConfiguration<Topic>
    {
        public TopicMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.CreateDate).HasColumnType("smalldatetime").IsRequired();
            this.Property(x => x.ReplyCount).IsRequired();
            this.Property(x => x.Slug).HasMaxLength(150);
            this.Property(x => x.Title).HasMaxLength(150);
            this.Property(x => x.ViewCount).IsRequired();

            this.HasMany(x => x.Posts).WithRequired(x => x.Topic).HasForeignKey(x => x.TopicId).WillCascadeOnDelete(false);
        }
    }
}