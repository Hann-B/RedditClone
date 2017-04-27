namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VotePostUserFKPK1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsUpVote = c.Boolean(nullable: false),
                        PostId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        OnePost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RedditPosts", t => t.OnePost_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OnePost_Id);
            
            AddColumn("dbo.RedditPosts", "DownVotes_Id", c => c.Int());
            AddColumn("dbo.RedditPosts", "UpVotes_Id", c => c.Int());
            CreateIndex("dbo.RedditPosts", "DownVotes_Id");
            CreateIndex("dbo.RedditPosts", "UpVotes_Id");
            AddForeignKey("dbo.RedditPosts", "DownVotes_Id", "dbo.Votes", "Id");
            AddForeignKey("dbo.RedditPosts", "UpVotes_Id", "dbo.Votes", "Id");
            DropColumn("dbo.RedditPosts", "UpVotes");
            DropColumn("dbo.RedditPosts", "DownVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RedditPosts", "DownVotes", c => c.Int(nullable: false));
            AddColumn("dbo.RedditPosts", "UpVotes", c => c.Int(nullable: false));
            DropForeignKey("dbo.RedditPosts", "UpVotes_Id", "dbo.Votes");
            DropForeignKey("dbo.RedditPosts", "DownVotes_Id", "dbo.Votes");
            DropForeignKey("dbo.Votes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "OnePost_Id", "dbo.RedditPosts");
            DropIndex("dbo.Votes", new[] { "OnePost_Id" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.RedditPosts", new[] { "UpVotes_Id" });
            DropIndex("dbo.RedditPosts", new[] { "DownVotes_Id" });
            DropColumn("dbo.RedditPosts", "UpVotes_Id");
            DropColumn("dbo.RedditPosts", "DownVotes_Id");
            DropTable("dbo.Votes");
        }
    }
}
