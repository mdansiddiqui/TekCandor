namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FilterTable : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MyFilter",
            //    c => new
            //    {
            //        Id = c.Long(nullable: false, identity: true),
            //        name = c.String(maxLength: 128, unicode: false),
            //        CreatedUser = c.String(maxLength: 128, unicode: false),
            //        CreatedDateTime = c.DateTime(),
            //        isDeleted = c.Boolean(nullable: false)
            //    })
            //    .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            //DropTable("dbo.MyFilter");
        }
    }
}
