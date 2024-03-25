namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hub",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    CityId = c.Long(),
                    Code = c.String(maxLength: 128),
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
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Hub");
        }
    }
}
