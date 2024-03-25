namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ReportFilter : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MyReportFilter",
            //    c => new
            //    {
            //        Id = c.Long(nullable: false, identity: true),
            //        ReportId = c.Long(nullable: false),
            //        FilterId = c.Long(nullable: false),
            //        CreatedUser = c.String(maxLength: 128, unicode: false),
            //        CreatedDateTime = c.DateTime(),
            //        isDeleted = c.Boolean(nullable: false)
            //    })
            //    .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            //DropTable("dbo.MyReportFilter");
        }
    }
}
