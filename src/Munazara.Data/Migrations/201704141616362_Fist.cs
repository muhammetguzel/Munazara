namespace Munazara.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Fist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 20),
                    Description = c.String(maxLength: 150),
                    Slug = c.String(),
                    Color = c.String(maxLength: 6),
                    CreateDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Topic",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 150),
                    CreateDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    Slug = c.String(maxLength: 150),
                    ViewCount = c.Int(nullable: false),
                    ReplyCount = c.Int(nullable: false),
                    CategoryId = c.Int(nullable: false),
                    MemberId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.MemberId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.MemberId);

            CreateTable(
                "dbo.Member",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 20),
                    Password = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 50),
                    Avatar = c.String(maxLength: 150),
                    IsActive = c.Boolean(nullable: false),
                    IsBanned = c.Boolean(nullable: false),
                    CreateDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    LastLoginDate = c.DateTime(storeType: "smalldatetime"),
                    Type = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Post",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    CreateDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    MemberId = c.Int(nullable: false),
                    TopicId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.MemberId)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .Index(t => t.MemberId)
                .Index(t => t.TopicId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Topic", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Post", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Post", "MemberId", "dbo.Member");
            DropIndex("dbo.Post", new[] { "TopicId" });
            DropIndex("dbo.Post", new[] { "MemberId" });
            DropIndex("dbo.Topic", new[] { "MemberId" });
            DropIndex("dbo.Topic", new[] { "CategoryId" });
            DropTable("dbo.Post");
            DropTable("dbo.Member");
            DropTable("dbo.Topic");
            DropTable("dbo.Category");
        }
    }
}