namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChequeDepositinfoTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChequeDepositInformation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CycleCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CityCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        serialNo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SenderBankCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SenderBranchCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiverBankCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceiverBranchCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SequenceNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IQATag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentSkew = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Piggyback = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageToolight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HorizontalStreaks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BelowMinimumCompressedImageSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AboveMaximumCompressedImageSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UndersizeImage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoldedorTornDocumentCorners = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoldedOrTornDocumentEdges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FramingError = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OversizeImage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageTooDark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FrontRearDimensionMismatch = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarbonStrip = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutOfFocus = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QRCodeMatch = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MICRPresent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StandardCheque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InstrumentDuplicate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageChequeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalChequesCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalChequesReturnCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CaptureAtNIFT_Branch = c.String(),
                        DeferredCheque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FraudChequeHistory = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Filler = c.String(),
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
            DropTable("dbo.ChequeDepositInformation");
        }
    }
}
