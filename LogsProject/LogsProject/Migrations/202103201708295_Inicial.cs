namespace LogsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogsProject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(maxLength: 100),
                        Type = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1050),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogsProject");
        }
    }
}
