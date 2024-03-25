namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ReturnReason_Tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReturnReason",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        code = c.String(maxLength: 50, unicode: false),
                        Version = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
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
            DropTable("dbo.ReturnReason");
        }
    }
}
