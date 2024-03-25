namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MyReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyReport",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    name = c.String(maxLength: 128, unicode: false),
                    url = c.String(maxLength: 128, unicode: false),
                    CreatedUser = c.String(maxLength: 128, unicode: false),
                    CreatedDateTime = c.DateTime(),
                    isDeleted = c.Boolean(nullable:false)
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.MyReport");
        }
    }
}
