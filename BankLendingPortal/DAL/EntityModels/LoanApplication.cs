using System.ComponentModel.DataAnnotations;

namespace BankLendingPortal.DAL.EntityModels
{
    public class LoanApplication
    {
        public string LoanAppId { get; set; } = null!;
        public string CustId { get; set; } = null!;
        public int LoanAmt { get; set; }
        public int NoOfYears { get; set; }

        public string? Purpose { get; set; }
        public string AppStatus { get; set; } = null!;
        public string TypeOfLoan { get; set; } = null!;
        public DateTime LoanAppDate { get; set; }
        public string Status { get; set; } = null!;

        public CustomerMaster customerMaster { get; set; } = null!;

        public virtual ICollection<LoanAppDetailMaster> LoanAppDetailMasters { get; set; } = null!;

        public virtual ICollection<CreditRisk> CreditRisks { get; set; } = null!;
    }
}
