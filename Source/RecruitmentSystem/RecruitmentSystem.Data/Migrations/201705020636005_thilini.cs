namespace RecruitmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thilini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewSkills",
                c => new
                    {
                        NewSkillID = c.Int(nullable: false, identity: true),
                        NewSkillType = c.String(),
                        Description = c.String(),
                        Qualification = c.String(),
                        Parent_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewSkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewSkills");
        }
    }
}
