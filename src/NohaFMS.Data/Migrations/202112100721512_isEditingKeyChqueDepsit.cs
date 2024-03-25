namespace NohaFMS.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class isEditingKeyChqueDepsit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChequeDepositInformation", "isEditing", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
