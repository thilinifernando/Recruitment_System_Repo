 namespace RecruitmentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "ReferenceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "ReferenceID", c => c.String());
        }
    }
}
