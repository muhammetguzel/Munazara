using Munazara.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munazara.Data.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasMaxLength(20);
            this.Property(x => x.Color).HasMaxLength(7);
            this.Property(x => x.Description).HasMaxLength(120);
            this.Property(x => x.CreateDate).HasColumnType("smalldatetime").IsRequired();

            this.HasMany(x => x.Topics).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
        }
    }
}