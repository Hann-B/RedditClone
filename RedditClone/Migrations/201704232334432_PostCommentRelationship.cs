namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostCommentRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "RedditPostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "RedditPostId");
            AddForeignKey("dbo.Comments", "RedditPostId", "dbo.RedditPosts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RedditPostId", "dbo.RedditPosts");
            DropIndex("dbo.Comments", new[] { "RedditPostId" });
            DropColumn("dbo.Comments", "RedditPostId");
        }
    }
}
