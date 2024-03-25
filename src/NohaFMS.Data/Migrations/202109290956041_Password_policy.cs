namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Password_policy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordPolicy",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NameOther = c.String(),
                        Description = c.String(),
                        CountHistory = c.Int(nullable: false),
                        ExpiryDays = c.Int(nullable: false),
                        NotifyDays = c.Int(nullable: false),
                        AccountDisableDays = c.Int(nullable: false),
                        InvalidLoginEntry = c.Int(nullable: false),
                        FirstReset = c.Boolean(nullable: false),
                        CyclicPassword = c.Boolean(nullable: false),
                        Version = c.Int(nullable: false),
                        Name = c.String(maxLength: 128),
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
            DropTable("dbo.PasswordPolicy");
        }
    }
}
