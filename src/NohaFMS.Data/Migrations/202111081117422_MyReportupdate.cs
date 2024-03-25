namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MyReportupdate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MyReport",
            //    c => new
            //    {
            //        Id = c.Long(nullable: false, identity: true),
            //        name = c.String(maxLength: 128, unicode: false),
            //        url = c.String(maxLength: 128, unicode: false),
            //        IsNew = c.Boolean(nullable: false),
            //        IsDeleted = c.Boolean(nullable: false),
            //        CreatedUser = c.String(maxLength: 128),
            //        CreatedDateTime = c.DateTime(),
            //        ModifiedUser = c.String(maxLength: 128),
            //        ModifiedDateTime = c.DateTime(),
            //    })
            //    .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
   //         DropTable("dbo.MyReport");
        }
    }
}
