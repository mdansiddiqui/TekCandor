namespace NohaFMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updatedChequeDepositTableForDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChequeDepositInformation", "serialNo", c => c.String(maxLength: 9, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SenderBankCode", c => c.String(maxLength: 9, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SenderBranchCode", c => c.String(maxLength: 9, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ReceiverBankCode", c => c.String(maxLength: 3, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ReceiverBranchCode", c => c.String(maxLength: 4, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ChequeNumber", c => c.String(maxLength: 8, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "AccountNumber", c => c.String(maxLength: 16, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SequenceNumber", c => c.String(maxLength: 9, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TransactionCode", c => c.String(maxLength: 3, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "IQATag", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "DocumentSkew", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "Piggyback", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ImageToolight", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "HorizontalStreaks", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "BelowMinimumCompressedImageSize", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "AboveMaximumCompressedImageSize", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "UndersizeImage", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FoldedorTornDocumentCorners", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FoldedOrTornDocumentEdges", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FramingError", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "OversizeImage", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ImageTooDark", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FrontRearDimensionMismatch", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "CarbonStrip", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "OutOfFocus", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "QRCodeMatch", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "UV", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "MICRPresent", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "StandardCheque", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "InstrumentDuplicate", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TotalChequesCount", c => c.String(maxLength: 5, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TotalChequesReturnCount", c => c.String(maxLength: 5, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "CaptureAtNIFT_Branch", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "DeferredCheque", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FraudChequeHistory", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "Filler", c => c.String(maxLength: 28, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "status", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("dbo.ChequeDepositInformation", "status", c => c.String(maxLength: 2));
            AlterColumn("dbo.ChequeDepositInformation", "Filler", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FraudChequeHistory", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "DeferredCheque", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "CaptureAtNIFT_Branch", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TotalChequesReturnCount", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TotalChequesCount", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "InstrumentDuplicate", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "StandardCheque", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "MICRPresent", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "UV", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "QRCodeMatch", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "OutOfFocus", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "CarbonStrip", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FrontRearDimensionMismatch", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ImageTooDark", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "OversizeImage", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FramingError", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FoldedOrTornDocumentEdges", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "FoldedorTornDocumentCorners", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "UndersizeImage", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "AboveMaximumCompressedImageSize", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "BelowMinimumCompressedImageSize", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "HorizontalStreaks", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ImageToolight", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "Piggyback", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "DocumentSkew", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "IQATag", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "TransactionCode", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SequenceNumber", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "AccountNumber", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ChequeNumber", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ReceiverBranchCode", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "ReceiverBankCode", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SenderBranchCode", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "SenderBankCode", c => c.String(maxLength: 2, unicode: false));
            AlterColumn("dbo.ChequeDepositInformation", "serialNo", c => c.String(maxLength: 2, unicode: false));
        }
    }
}
