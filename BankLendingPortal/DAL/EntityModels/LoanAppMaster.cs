namespace BankLendingPortal.DAL.EntityModels
{
    public class LoanAppMaster
    {
        public string LoanAppId { get; set; } = null!;
        public int InterestRate { get; set; }
        public DateTime ApplicationDate { get; set; }

        public virtual ICollection<LoanAppDetailMaster> LoanAppDetailMasters { get; set; } = null!;

    }
}
