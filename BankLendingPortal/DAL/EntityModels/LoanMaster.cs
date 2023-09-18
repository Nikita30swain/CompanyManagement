namespace BankLendingPortal.DAL.EntityModels
{
    public class LoanMaster
    {
        public string LoanId { get; set; } = null!;
        public string Typeofloan { get; set; } = null!;
        public int InterestRate { get; set; }
        public DateTime DateOfCreation { get; set; }

    }
}
