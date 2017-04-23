namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostUserRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedditPosts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RedditPosts", "UserId");
            AddForeignKey("dbo.RedditPosts", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RedditPosts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RedditPosts", new[] { "UserId" });
            DropColumn("dbo.RedditPosts", "UserId");
        }
    }
}
