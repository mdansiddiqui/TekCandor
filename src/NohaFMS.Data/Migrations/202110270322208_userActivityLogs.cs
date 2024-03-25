namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameLiveMonitor : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.UserActivityLogs",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Description = c.String(maxLength:500),
                    UserId=c.Long(nullable:true),
                    CreatedLogTime=c.DateTime(),
                    IsNew=c.Boolean(nullable:true),
                    IsDeleted=c.Boolean(nullable:true)
                    //Version = c.Int(nullable: false),
                    //Name = c.String(maxLength: 256),
                    //IsNew = c.Boolean(nullable: false),
                    //IsDeleted = c.Boolean(nullable: false),
                    //CreatedUser = c.String(maxLength: 128),
                    //CreatedDateTime = c.DateTime(),
                    //ModifiedUser = c.String(maxLength: 128),
                    //ModifiedDateTime = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.UserActivityLogs");
        }
    }
}
