namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class LiveMonitoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LiveMonitoring",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LiveName = c.String(maxLength: 10, unicode: false),
                        BranchName = c.String(maxLength: 10, unicode: false),
                        BranchCode = c.String(maxLength: 10, unicode: false),
                        CityName = c.String(maxLength: 10, unicode: false),
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
            DropTable("dbo.LiveMonitoring");
        }
    }
}
