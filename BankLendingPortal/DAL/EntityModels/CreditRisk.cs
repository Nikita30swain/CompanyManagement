using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankLendingPortal.DAL.EntityModels
{
    public class CreditRisk
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CrId { get; set; } //{ get { return "CR" + LoanAppId; } }

        public string LoanAppId { get; set; } = null!;

        [Range(200, 700)]
        public int CreditScore { get; set; }

        [Range(1, int.MaxValue)]
        public int Emi { get; set; }

        public string BasicCheck { get; set; } = null!;

        public LoanApplication LoanApplication { get; set; } = null!;

    }
}
