using System.ComponentModel.DataAnnotations;

namespace BankLendingPortal.DAL.EntityModels
{
    public class CustomerMaster
    {
        [StringLength(6, MinimumLength = 6)]
        public string CustId { get; set; } = null!;

        [StringLength(50, MinimumLength = 3)]
        public string CustFirstName { get; set; } = null!;

        [StringLength(50, MinimumLength = 3)]
        public string? CustLastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public int ContactNo { get; set; }
        public int AadharCard { get; set; }
        public string? EmailId { get; set; }
        public DateTime BirthDate { get; set; }
        public int MonthlySalary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanApplication>? LoanApplications { get; set; }

       
    }
}
