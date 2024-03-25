namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class branch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                   "dbo.Branch",
                   c => new
                   {
                       Id = c.Long(nullable: false, identity: true),
                       HubId = c.Long(),
                       Code = c.String(maxLength: 128),
                       Email = c.String(maxLength: 128),
                       NIFTBranchCode = c.String(maxLength: 128),
                       Version = c.Int(nullable: false),
                       Name = c.String(maxLength: 256),
                       IsNew = c.Boolean(nullable: false),
                       IsDeleted = c.Boolean(nullable: false),
                       CreatedUser = c.String(maxLength: 128),
                       CreatedDateTime = c.DateTime(),
                       ModifiedUser = c.String(maxLength: 128),
                       ModifiedDateTime = c.DateTime(),
                   })
                .PrimaryKey(t => t.Id)
             .ForeignKey("dbo.Hub", t => t.HubId)
                .Index(t => t.HubId);

        }

        public override void Down()
        {
            DropTable("dbo.Branch");
        }
    }
}
