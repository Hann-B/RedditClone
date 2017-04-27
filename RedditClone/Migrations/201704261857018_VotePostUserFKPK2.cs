namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VotePostUserFKPK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RedditPosts", "DownVotes_Id", "dbo.Votes");
            DropForeignKey("dbo.RedditPosts", "UpVotes_Id", "dbo.Votes");
            DropIndex("dbo.RedditPosts", new[] { "DownVotes_Id" });
            DropIndex("dbo.RedditPosts", new[] { "UpVotes_Id" });
            AddColumn("dbo.RedditPosts", "UpVotes", c => c.Int(nullable: false));
            AddColumn("dbo.RedditPosts", "DownVotes", c => c.Int(nullable: false));
            DropColumn("dbo.RedditPosts", "DownVotes_Id");
            DropColumn("dbo.RedditPosts", "UpVotes_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RedditPosts", "UpVotes_Id", c => c.Int());
            AddColumn("dbo.RedditPosts", "DownVotes_Id", c => c.Int());
            DropColumn("dbo.RedditPosts", "DownVotes");
            DropColumn("dbo.RedditPosts", "UpVotes");
            CreateIndex("dbo.RedditPosts", "UpVotes_Id");
            CreateIndex("dbo.RedditPosts", "DownVotes_Id");
            AddForeignKey("dbo.RedditPosts", "UpVotes_Id", "dbo.Votes", "Id");
            AddForeignKey("dbo.RedditPosts", "DownVotes_Id", "dbo.Votes", "Id");
        }
    }
}
