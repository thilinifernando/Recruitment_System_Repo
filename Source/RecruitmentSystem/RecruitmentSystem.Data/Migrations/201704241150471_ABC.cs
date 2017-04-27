namespace RecruitmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ABC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        CVPath = c.String(),
                        Job_JobID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.Job_JobID)
                .Index(t => t.Job_JobID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Create_User_ID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobID);
            
            CreateTable(
                "dbo.InterviewStages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.String(),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillType = c.String(),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        CommentedTime = c.DateTime(nullable: false),
                        Candidate_ID = c.Int(),
                        CommentedBy_ID = c.Int(),
                        Stage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.Candidate_ID)
                .ForeignKey("dbo.Interviewers", t => t.CommentedBy_ID)
                .ForeignKey("dbo.InterviewStages", t => t.Stage_Id)
                .Index(t => t.Candidate_ID)
                .Index(t => t.CommentedBy_ID)
                .Index(t => t.Stage_Id);
            
            CreateTable(
                "dbo.Interviewers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        InboxID = c.Int(nullable: false, identity: true),
                        EmailName = c.String(),
                        EmailSubject = c.String(),
                        EmailBodyText = c.String(),
                        CvPath = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InboxID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Stage_Id", "dbo.InterviewStages");
            DropForeignKey("dbo.Comments", "CommentedBy_ID", "dbo.Interviewers");
            DropForeignKey("dbo.Comments", "Candidate_ID", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.Skills", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.InterviewStages", "JobId", "dbo.Jobs");
            DropIndex("dbo.Comments", new[] { "Stage_Id" });
            DropIndex("dbo.Comments", new[] { "CommentedBy_ID" });
            DropIndex("dbo.Comments", new[] { "Candidate_ID" });
            DropIndex("dbo.Skills", new[] { "JobId" });
            DropIndex("dbo.InterviewStages", new[] { "JobId" });
            DropIndex("dbo.Candidates", new[] { "Job_JobID" });
            DropTable("dbo.Inboxes");
            DropTable("dbo.Interviewers");
            DropTable("dbo.Comments");
            DropTable("dbo.Skills");
            DropTable("dbo.InterviewStages");
            DropTable("dbo.Jobs");
            DropTable("dbo.Candidates");
        }
    }
}
