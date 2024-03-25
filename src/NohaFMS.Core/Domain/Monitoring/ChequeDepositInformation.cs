/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    [System.ComponentModel.DataAnnotations.Schema.Table("ChequeDepositInformation")]
    public class ChequeDepositInformation : BaseEntity
    {

        // public int Id { get; set; }
        public System.DateTime Date { get; set; }
        [Column(TypeName = "varchar")]
        public string CycleCode { get; set; }
        [Column(TypeName = "varchar")]
        public string CityCode { get; set; }
        [Column(TypeName = "varchar")]
        public string serialNo { get; set; }
        [Column(TypeName = "varchar")]
        public string SenderBankCode { get; set; }
        [Column(TypeName = "varchar")]
        public string SenderBranchCode { get; set; }
        [Column(TypeName = "varchar")]
        public string ReceiverBankCode { get; set; }
        [Column(TypeName = "varchar")]
        public string ReceiverBranchCode { get; set; }
        [Column(TypeName = "varchar")]
        public string ChequeNumber { get; set; }
        [Column(TypeName = "varchar")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "varchar")]
        public string SequenceNumber { get; set; }
        [Column(TypeName = "varchar")]
        public string TransactionCode { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "varchar")]
        public string IQATag { get; set; }
        [Column(TypeName = "varchar")]
        public string DocumentSkew { get; set; }
        [Column(TypeName = "varchar")]
        public string Piggyback { get; set; }
        [Column(TypeName = "varchar")]
        public string ImageToolight { get; set; }
        [Column(TypeName = "varchar")]

        public string HorizontalStreaks { get; set; }
        [Column(TypeName = "varchar")]
        public string BelowMinimumCompressedImageSize { get; set; }
        [Column(TypeName = "varchar")]
        public string AboveMaximumCompressedImageSize { get; set; }
        [Column(TypeName = "varchar")]
        public string UndersizeImage { get; set; }
        [Column(TypeName = "varchar")]
        public string FoldedorTornDocumentCorners { get; set; }
        [Column(TypeName = "varchar")]
        public string FoldedOrTornDocumentEdges { get; set; }
        [Column(TypeName = "varchar")]
        public string FramingError { get; set; }
        [Column(TypeName = "varchar")]
        public string OversizeImage { get; set; }
        [Column(TypeName = "varchar")]
        public string ImageTooDark { get; set; }
        [Column(TypeName = "varchar")]
        public string FrontRearDimensionMismatch { get; set; }
        [Column(TypeName = "varchar")]
        public string CarbonStrip { get; set; }
        [Column(TypeName = "varchar")]
        public string OutOfFocus { get; set; }
        [Column(TypeName = "varchar")]
        public string QRCodeMatch { get; set; }
        [Column(TypeName = "varchar")]
        public string UV { get; set; }
        [Column(TypeName = "varchar")]
        public string MICRPresent { get; set; }
        [Column(TypeName = "varchar")]
        public string StandardCheque { get; set; }
        [Column(TypeName = "varchar")]
        public string InstrumentDuplicate { get; set; }

        public decimal AverageChequeAmount { get; set; }
        [Column(TypeName = "varchar")]
        public string TotalChequesCount { get; set; }

        [Column(TypeName = "varchar")]
        public string TotalChequesReturnCount { get; set; }
        [Column(TypeName = "varchar")]
        public string CaptureAtNIFT_Branch { get; set; }
        [Column(TypeName = "varchar")]
        public string DeferredCheque { get; set; }
        [Column(TypeName = "varchar")]
        public string Remarks { get; set; }
        [Column(TypeName = "varchar")]
        public string FraudChequeHistory { get; set; }
        [Column(TypeName = "varchar")]
        public string Filler { get; set; }
        public byte[] imgF { get; set; }
        public byte[] imgR { get; set; }
        public byte[] imgU { get; set; }
        public string status { get; set; }
        public bool? Export { get; set; }
        [Column(TypeName = "varchar")]
        public string Returnreasone { get; set; }
        public bool Error { get; set; }
        [Column(TypeName = "varchar")]
        public string HubCode { get; set; }
        public Nullable<System.DateTime> chequeDate { get; set; }
        public bool? Callback { get; set; }
        public bool Callbacksend { get; set; }
        public bool Auth { get; set; }
        //public bool isEditing { get; set; }
        public string NiftBranchCode { get; set; }

        public string InstrumentNo { get; set; }
        public System.DateTime Importtime { get; set; }
        [Column(TypeName = "varchar")]
     
        public List<ChequeDepositInformation> ChequeDepositsList { get; set; }
    }
}
