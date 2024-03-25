namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconfigrationform : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.City",
              c => new
              {
                  Id = c.Long(nullable: false, identity: true),
                  Name = c.String(maxLength: 256, storeType: "nvarchar"),
                  Code = c.String(maxLength: 128, storeType: "nvarchar"),
                  IsNew = c.Boolean(nullable: false),
                  IsDeleted = c.Boolean(nullable: false),
                  CreatedUser = c.String(maxLength: 128, storeType: "nvarchar"),
                  CreatedDateTime = c.DateTime(precision: 0),
                  ModifiedUser = c.String(maxLength: 128, storeType: "nvarchar"),
                  ModifiedDateTime = c.DateTime(precision: 0),
              })
              .PrimaryKey(t => t.Id);

            


        }
        
        public override void Down()
        {
        }
    }
}
