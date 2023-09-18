namespace BankLendingPortal.DAL.EntityModels
{
    public class LoanAppDetailMaster
    {
        public string Id { get; set; } = null!;
        public string LoanAppId { get; set; } = null!;
        public int MonthNo { get; set; }
        public int Installment { get; set; }
        public int InterestRate { get; set; }
        public int POutStandingBeginOfMon { get; set; }
        public int PRepayment { get; set; }
        public int PrOutStandingEndOfMon { get; set; }
        public DateTime LastDateofinstallPay { get; set; }

        public LoanApplication LoanApplication { get; set; } = null!;

        public LoanAppMaster LoanAppMaster { get; set; } = null!;


    }
}
