namespace RecruitmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interviewers", "InterviewStage_Id", "dbo.InterviewStages");
            DropForeignKey("dbo.Skills", "InterviewStage_Id", "dbo.InterviewStages");
            DropIndex("dbo.Interviewers", new[] { "InterviewStage_Id" });
            DropIndex("dbo.Skills", new[] { "InterviewStage_Id" });
            DropColumn("dbo.Interviewers", "InterviewStage_Id");
            DropColumn("dbo.Skills", "InterviewStage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "InterviewStage_Id", c => c.Int());
            AddColumn("dbo.Interviewers", "InterviewStage_Id", c => c.Int());
            CreateIndex("dbo.Skills", "InterviewStage_Id");
            CreateIndex("dbo.Interviewers", "InterviewStage_Id");
            AddForeignKey("dbo.Skills", "InterviewStage_Id", "dbo.InterviewStages", "Id");
            AddForeignKey("dbo.Interviewers", "InterviewStage_Id", "dbo.InterviewStages", "Id");
        }
    }
}
