using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Repositories;

public class BankContext : DbContext {
    public BankContext() {
        const Environment.SpecialFolder folder =
            Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "bank.db");
        //Console.WriteLine(DbPath);
    }

    public BankContext(DbContextOptions<BankContext> dbContextOptions) : base(
        dbContextOptions) {
    }

    public DbSet<Transaction> Transactions { get; set; } = null!;

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    private string DbPath { get; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Account>()
            .HasDiscriminator<string>("Type")
            .HasValue<SavingAccount>("SavingsAccount")
            .HasValue<CurrentAccount>("CurrentAccount");

        modelBuilder.Entity<Transaction>()
            .HasDiscriminator<string>("Type")
            .HasValue<Deposit>("Deposit")
            .HasValue<Transfer>("Transfer")
            .HasValue<Payment>("Payment");

        modelBuilder.Entity<SavingAccount>()
            .Property(e => e.Interest)
            .HasColumnName("Interest");
        modelBuilder.Entity<CurrentAccount>()
            .Property(e => e.Interest)
            .HasColumnName("Interest");

        modelBuilder.Entity<SavingAccount>()
            .Property(e => e.WithdrawLimit)
            .HasColumnName("WithdrawLimit");
        modelBuilder.Entity<CurrentAccount>()
            .Property(e => e.WithdrawLimit)
            .HasColumnName("WithdrawLimit");


        modelBuilder.Entity<Transaction>()
            .HasIndex(e => new { e.ToAccount })
            .IsUnique(false);

        modelBuilder.Entity<Transaction>()
            .HasIndex(e => new { e.FromAccount })
            .IsUnique(false);


        modelBuilder.Entity<Bill>()
            .HasIndex(e => new { e.ToAccount })
            .IsUnique(false);


        modelBuilder.Entity<Person>()
            .HasIndex(e => new { e.SocialSecurityNumber })
            .IsUnique();


        modelBuilder.Entity<Person>()
            .HasIndex(e => new { e.Id })
            .IsUnique();
    }

    // few adjustments for tests
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}