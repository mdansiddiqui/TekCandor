namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcycle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                   "dbo.Cycle",
                   c => new
                   {
                       Id = c.Long(nullable: false, identity: true),
                       Days = c.Int(),
                       Name = c.String(maxLength: 256),
                       Version = c.Int(nullable: false),
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
            DropTable("dbo.Cycle");
        }
    }
}
