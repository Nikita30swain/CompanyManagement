namespace BankLendingPortal.DAL.EntityModels
{
    public class PaymentTrack
    {
        public string PaymentTrackId { get; set; } = null!;
        public string LoanAppId { get; set; } = null!;
        public int Month_no { get; set; }
        public string Status { get; set; } = null!;
        public DateTime DueDateOfPayment { get; set; }
        public DateTime PaymentRecieveDate { get; set; }
    }
}
