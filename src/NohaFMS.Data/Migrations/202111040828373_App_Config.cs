namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class App_Config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationConfig",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Key = c.String(maxLength: 128, unicode: false),
                    Value = c.String(maxLength: 128, unicode: false),
                    CreatedUser = c.String(maxLength: 128, unicode: false),
                    CreatedDateTime = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.ApplicationConfig");
        }
    }
}
