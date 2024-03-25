namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ClearingStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                   "dbo.ClearingStatuses",
                   c => new
                   {
                       Id = c.Long(nullable: false, identity: true),
                       Text = c.String(maxLength: 256),
                       Value = c.String(maxLength: 256),
                       IsNew = c.Boolean(nullable: false),
                       IsDeleted = c.Boolean(nullable: false),
                       CreatedUser = c.String(maxLength: 128),
                       CreatedDateTime = c.DateTime(),
                       ModifiedUser = c.String(maxLength: 128),
                       ModifiedDateTime = c.DateTime(),
                   })
                .PrimaryKey(t => t.Id);
             
        }
        
        public override void Down()
        {
            DropTable("dbo.ClearingStatuses");
        }
    }
}
