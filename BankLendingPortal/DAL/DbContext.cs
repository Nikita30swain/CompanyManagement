using BankLendingPortal.DAL.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System.Diagnostics;
using System.Xml;

namespace BankLendingPortal.DAL
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        /* // Our code
        public DefaultContext()
        {
        }
        
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public DefaultContext()
            : base("name=DefaultContext")
        {
        }
        */

        public virtual DbSet<CreditRisk>? CreditRisks { get; set; }

        public virtual DbSet<CustomerMaster>? CustomerMasters { get; set; }

        public virtual DbSet<LoanAppDetailMaster>? LoanAppDetailMasters { get; set; }

        public virtual DbSet<LoanApplication>? LoanApplications { get; set; }

        public virtual DbSet<LoanAppMaster>? LoanAppMasters { get; set; }

        public virtual DbSet<PaymentTrack>? PaymentTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many relationship from customerMaster to loanApplication
            modelBuilder.Entity<LoanApplication>()
                .HasOne<CustomerMaster>(e => e.customerMaster)
                .WithMany(c => c.LoanApplications)
                .HasForeignKey(e => e.CustId);

            modelBuilder.Entity<LoanApplication>()
                .HasKey(e => e.LoanAppId);

            // one to many relationship from loanApplication to loanAppDetailMaster
            modelBuilder.Entity<LoanAppDetailMaster>()
                .HasOne<LoanApplication>(e => e.LoanApplication)
                .WithMany(c => c.LoanAppDetailMasters)
                .HasForeignKey(e => e.LoanAppId);

            modelBuilder.Entity<LoanAppDetailMaster>()
                .HasKey(e => e.Id);

            // one to many relationship from loanApplication to creditRisk
            modelBuilder.Entity<CreditRisk>()
                .HasOne<LoanApplication>(e => e.LoanApplication)
                .WithMany(c => c.CreditRisks)
                .HasForeignKey(e => e.LoanAppId);

            modelBuilder.Entity<CreditRisk>()
                .HasKey(k => k.CrId);

            // one to many relationship from LoanAppMaster to loanAppDetailMaster
            modelBuilder.Entity<LoanAppDetailMaster>()
                .HasOne<LoanAppMaster>(e => e.LoanAppMaster)
                .WithMany(c => c.LoanAppDetailMasters)
                .HasForeignKey(e => e.LoanAppId);

            modelBuilder.Entity<PaymentTrack>()
                .HasKey(k => k.PaymentTrackId);

            modelBuilder.Entity<LoanAppMaster>()
                .HasKey(k => k.LoanAppId);

            modelBuilder.Entity<CustomerMaster>()
                .HasKey(k => k.CustId);

            modelBuilder.Entity<LoanMaster>()
                .HasKey(k => new { k.LoanId, k.Typeofloan, k.DateOfCreation});

        }
    }
}
