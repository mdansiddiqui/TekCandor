namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instrumn_no : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instruments",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    code = c.String(maxLength: 50, unicode: false),
                    Name = c.String(maxLength: 256),
                    IsNew = c.Boolean(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    CreatedUser = c.String(maxLength: 128),
                    CreatedDateTime = c.DateTime(),
                    ModifiedUser = c.String(maxLength: 128),
                    ModifiedDateTime = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
            AddColumn("dbo.ChequeDepositInformation", "NifTBranchCode", c => c.String(maxLength:512));
        }
        
        public override void Down()
        {
        }
    }
}
