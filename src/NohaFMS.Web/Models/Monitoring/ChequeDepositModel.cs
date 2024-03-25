using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NohaFMS.Web
{
    public class ChequeDepositModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Date")]
        [DataType(DataType.Date)]

        public System.DateTime? Date { get; set; }
        [BaseEamResourceDisplayName("Cycle Code")]
        public string CycleCode { get; set; }
        [BaseEamResourceDisplayName("City Code")]
        public string CityCode { get; set; }
        [BaseEamResourceDisplayName("Serial No")]
        public string serialNo { get; set; }
        [BaseEamResourceDisplayName("Sender Bank Code")]
        public string SenderBankCode { get; set; }
        [BaseEamResourceDisplayName("SenderBranch Code")]
        public string SenderBranchCode { get; set; }
        [BaseEamResourceDisplayName("Receiver BankCode")]

        public string ReceiverBankCode { get; set; }
        [BaseEamResourceDisplayName("Receiver Branch Code")]
        public string ReceiverBranchCode { get; set; }
        [BaseEamResourceDisplayName("Receiver Branch Name")]
        public string NiftBranchCode { get; set; }
        [BaseEamResourceDisplayName("Nift Branch Code")]
        public string InstrumentNo { get; set; }
        [BaseEamResourceDisplayName("Instrument Number")]
        public string ReceiverBranchName { get; set; }
        [BaseEamResourceDisplayName("Cheque Number")]
        public string ChequeNumber { get; set; }
        [BaseEamResourceDisplayName("Account Number")]
        public string AccountNumber { get; set; }
        [BaseEamResourceDisplayName("Sequence Number")]
        public string SequenceNumber { get; set; }
        [BaseEamResourceDisplayName("TransactionCode")]
        public string TransactionCode { get; set; }
        [BaseEamResourceDisplayName(" Amount")]
        [UIHint("DecimalNullable")]
        public decimal Amount { get; set; }
        [BaseEamResourceDisplayName(" IQATag")]
        public string IQATag { get; set; }
        [BaseEamResourceDisplayName(" Document Skew")]
        public string DocumentSkew { get; set; }
        [BaseEamResourceDisplayName("Piggy back")]
        public string Piggyback { get; set; }
        [BaseEamResourceDisplayName(" Image Too light")]
        public string ImageToolight { get; set; }
        [BaseEamResourceDisplayName("HorizontalStreaks")]
        public string HorizontalStreaks { get; set; }
        [BaseEamResourceDisplayName("BMC Image Size")]
        public string BelowMinimumCompressedImageSize { get; set; }
        [BaseEamResourceDisplayName("AMC Image Size")]
        public string AboveMaximumCompressedImageSize { get; set; }
        [BaseEamResourceDisplayName("Under size Image")]
        public string UndersizeImage { get; set; }
        [BaseEamResourceDisplayName("Folded or Torn Document Corners")]
        public string FoldedorTornDocumentCorners { get; set; }
        [BaseEamResourceDisplayName("Folded Or Torn Document Edges")]
        public string FoldedOrTornDocumentEdges { get; set; }
        [BaseEamResourceDisplayName("Framing Error")]
        public string FramingError { get; set; }
        [BaseEamResourceDisplayName("Oversize Image")]
        public string OversizeImage { get; set; }
        [BaseEamResourceDisplayName("Image Too Dark")]
        public string ImageTooDark { get; set; }
        [BaseEamResourceDisplayName("Front Rear Dimension Mismatch")]
        public string FrontRearDimensionMismatch { get; set; }
        [BaseEamResourceDisplayName("Carbon Strip")]
        public string CarbonStrip { get; set; }
        [BaseEamResourceDisplayName("Out Of Focus")]
        public string OutOfFocus { get; set; }
        [BaseEamResourceDisplayName("QR Code Match")]
        public string QRCodeMatch { get; set; }
        [BaseEamResourceDisplayName("UV")]
        public string UV { get; set; }
        [BaseEamResourceDisplayName("MICR Present")]
        public string MICRPresent { get; set; }
        [BaseEamResourceDisplayName("Standar dCheque")]
        public string StandardCheque { get; set; }
        [BaseEamResourceDisplayName("Instrument Duplicate")]
        public string InstrumentDuplicate { get; set; }
        [BaseEamResourceDisplayName("Average Cheque Amount")]
        [UIHint("DecimalNullable")]
        public decimal AverageChequeAmount { get; set; }
        [BaseEamResourceDisplayName("Total Cheques Count")]
        public string TotalChequesCount { get; set; }
        [BaseEamResourceDisplayName("Total Cheques Return Count")]

        public string TotalChequesReturnCount { get; set; }
        [BaseEamResourceDisplayName("Capture At")]
        public string CaptureAtNIFT_Branch { get; set; }
        [BaseEamResourceDisplayName("Deferred Cheque")]
        public string DeferredCheque { get; set; }
        [BaseEamResourceDisplayName("Fraud Cheque History")]
        public string FraudChequeHistory { get; set; }
        [BaseEamResourceDisplayName("Filler")]
        public string Filler { get; set; }
        [BaseEamResourceDisplayName("Front Image")]
        public string imgF { get; set; }
        [BaseEamResourceDisplayName("Rear Image")]
        public string imgR { get; set; }
        [BaseEamResourceDisplayName("UV Image")]
        public string imgU { get; set; }
        [BaseEamResourceDisplayName("Status")]
        public string status { get; set; }
        [BaseEamResourceDisplayName("Exported")]
        public bool? Export { get; set; }
        [BaseEamResourceDisplayName("Return Reason")]
        public string Returnreasone { get; set; }

        public bool Import { get; set; }
        [BaseEamResourceDisplayName("Error")]
        public bool Error { get; set; }
        [BaseEamResourceDisplayName("Hub Code")]
        public string HubCode { get; set; }
        [BaseEamResourceDisplayName("Error Fields Name")]
        public string ErrorFieldsName { get; set; }
        [BaseEamResourceDisplayName("Error Fields Name")]
        public List<string> NewErrorFieldsName { get; set; }
        [BaseEamResourceDisplayName("Exported")]
        public string Exported { get; set; }
        [BaseEamResourceDisplayName("Error")]
        public string Errors { get; set; }
      //  [BaseEamResourceDisplayName("Cheque Date")]
        [Required(ErrorMessage = "Enter the Cheque date.")]
       // [DataType(DataType.Date)]
        [BaseEamResourceDisplayName("Cheque Date")]
        public string chequeDate { get; set; }

        public bool? Callback { get; set; }
        public bool Callbacksend { get; set; }
        public bool Auth { get; set; }
        [BaseEamResourceDisplayName("Account Title")]
        public string AcccountTitle { get; set; }
        [BaseEamResourceDisplayName("Available Balance")]
        public int AvailableBalance { get; set; }
        [BaseEamResourceDisplayName("Ledger Balance")]
        public string LedgerBalance { get; set; }
            [BaseEamResourceDisplayName("Remarks")]
            public string Remarks { get; set; }
        //public bool isEditing { get; set; }



    }
}
