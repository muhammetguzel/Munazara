using Munazara.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munazara.Infrastructure.Data.Mapping
{
    public class MemberMapping : EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Avatar).HasMaxLength(150);
            this.Property(x => x.CreateDate).HasColumnType("smalldatetime").IsRequired();
            this.Property(x => x.Email).HasMaxLength(50).IsRequired();
            this.Property(x => x.IsActive).IsRequired();
            this.Property(x => x.IsBanned).IsRequired();
            this.Property(x => x.LastLoginDate).HasColumnType("smalldatetime").IsOptional();
            this.Property(x => x.Password).HasMaxLength(50).IsRequired();
            this.Property(x => x.Type).IsRequired();
            this.Property(x => x.UserName).HasMaxLength(20).IsRequired();

            this.HasMany(x => x.Topics).WithRequired(x => x.Member).HasForeignKey(x => x.MemberId).WillCascadeOnDelete(false);

            this.HasMany(x => x.Posts).WithRequired(x => x.Member).HasForeignKey(x => x.MemberId).WillCascadeOnDelete(false);
        }
    }
}