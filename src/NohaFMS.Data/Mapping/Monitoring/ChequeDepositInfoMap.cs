/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ChequeDepositInfoMap : NohaFMSEntityTypeConfiguration<ChequeDepositInformation>
    {
        public ChequeDepositInfoMap()
        {
            this.ToTable("ChequeDepositInformation");
            this.Property(s => s.Date);
            this.Property(s => s.CycleCode).HasMaxLength(2);
            this.Property(s => s.CityCode) ; 
            this.Property(s => s.serialNo).HasMaxLength(6); 
            this.Property(s => s.SenderBankCode).HasMaxLength(3);
            this.Property(s => s.SenderBranchCode).HasMaxLength(4);
            this.Property(s => s.ReceiverBankCode).HasMaxLength(3);
            this.Property(s => s.ReceiverBranchCode).HasMaxLength(4);
            this.Property(s => s.ChequeNumber).HasMaxLength(8);
            this.Property(s => s.AccountNumber).HasMaxLength(16);
            this.Property(s => s.SequenceNumber).HasMaxLength(9);
            this.Property(s => s.TransactionCode).HasMaxLength(3);
            this.Property(e => e.Amount);
            this.Property(s => s.IQATag).HasMaxLength(1);
            this.Property(s => s.DocumentSkew).HasMaxLength(1);
            this.Property(s => s.Piggyback).HasMaxLength(1);
            this.Property(s => s.ImageToolight).HasMaxLength(1);
            this.Property(s => s.HorizontalStreaks).HasMaxLength(1);
            this.Property(s => s.BelowMinimumCompressedImageSize).HasMaxLength(1);
            this.Property(s => s.AboveMaximumCompressedImageSize).HasMaxLength(1);
            this.Property(s => s.UndersizeImage).HasMaxLength(1);
            this.Property(s => s.FoldedorTornDocumentCorners).HasMaxLength(1);
            this.Property(e => e.FoldedOrTornDocumentEdges).HasMaxLength(1);
            this.Property(s => s.FramingError).HasMaxLength(1);
            this.Property(s => s.OversizeImage).HasMaxLength(1);
            this.Property(s => s.ImageTooDark).HasMaxLength(1);
            this.Property(s => s.FrontRearDimensionMismatch).HasMaxLength(1);
            this.Property(s => s.CarbonStrip).HasMaxLength(1);
            this.Property(s => s.OutOfFocus).HasMaxLength(1);
            this.Property(s => s.QRCodeMatch).HasMaxLength(1);
            this.Property(s => s.UV).HasMaxLength(1);
            this.Property(s => s.MICRPresent).HasMaxLength(1);
            this.Property(s => s.StandardCheque).HasMaxLength(1);
            this.Property(s => s.InstrumentDuplicate).HasMaxLength(1);
            this.Property(e => e.AverageChequeAmount);
            this.Property(s => s.TotalChequesCount).HasMaxLength(5);
            this.Property(s => s.TotalChequesReturnCount).HasMaxLength(5);
            this.Property(s => s.CaptureAtNIFT_Branch).HasMaxLength(1);
            this.Property(s => s.DeferredCheque).HasMaxLength(1);
            this.Property(s => s.FraudChequeHistory).HasMaxLength(1);
            this.Property(s => s.Filler).HasMaxLength(28);
            this.Property(s => s.imgF);
            this.Property(s => s.imgR);
            this.Property(s => s.imgU);
            this.Property(s => s.status).HasMaxLength(50);
            this.Property(s => s.Export);
            this.Property(s => s.Returnreasone).HasMaxLength(200); 
            this.Property(s => s.Error);
            this.Property(s => s.HubCode).HasMaxLength(4);
            this.Property(s => s.chequeDate);
            this.Property(s => s.Callback);
            this.Property(s => s.Callbacksend);
            this.Property(s => s.Importtime);





        }
    }
}