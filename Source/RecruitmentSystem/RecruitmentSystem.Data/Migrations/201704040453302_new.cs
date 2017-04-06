namespace RecruitmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
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
                        ReferenceID = c.String(),
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
                "dbo.Interviewers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Title = c.String(),
                        InterviewStage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InterviewStages", t => t.InterviewStage_Id)
                .Index(t => t.InterviewStage_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillType = c.String(),
                        JobId = c.Int(nullable: false),
                        InterviewStage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.InterviewStages", t => t.InterviewStage_Id)
                .Index(t => t.JobId)
                .Index(t => t.InterviewStage_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Stage_Id", "dbo.InterviewStages");
            DropForeignKey("dbo.Comments", "CommentedBy_ID", "dbo.Interviewers");
            DropForeignKey("dbo.Comments", "Candidate_ID", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "Job_JobID", "dbo.Jobs");
            DropForeignKey("dbo.Skills", "InterviewStage_Id", "dbo.InterviewStages");
            DropForeignKey("dbo.Skills", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.InterviewStages", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Interviewers", "InterviewStage_Id", "dbo.InterviewStages");
            DropIndex("dbo.Comments", new[] { "Stage_Id" });
            DropIndex("dbo.Comments", new[] { "CommentedBy_ID" });
            DropIndex("dbo.Comments", new[] { "Candidate_ID" });
            DropIndex("dbo.Skills", new[] { "InterviewStage_Id" });
            DropIndex("dbo.Skills", new[] { "JobId" });
            DropIndex("dbo.Interviewers", new[] { "InterviewStage_Id" });
            DropIndex("dbo.InterviewStages", new[] { "JobId" });
            DropIndex("dbo.Candidates", new[] { "Job_JobID" });
            DropTable("dbo.Comments");
            DropTable("dbo.Skills");
            DropTable("dbo.Interviewers");
            DropTable("dbo.InterviewStages");
            DropTable("dbo.Jobs");
            DropTable("dbo.Candidates");
        }
    }
}
