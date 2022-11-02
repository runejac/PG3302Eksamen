using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;
using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;

namespace A_Team.Core.Repositories;

public class BankContext : DbContext {
	public BankContext() {
		const Environment.SpecialFolder folder =
			Environment.SpecialFolder.LocalApplicationData;
		var path = Environment.GetFolderPath(folder);
		DbPath = Path.Join(path, "bank.db");

		Console.WriteLine(DbPath);
	}

	public DbSet<Account> Accounts { get; set; } = null!;
	public DbSet<Bill> Bills { get; set; } = null!;
	public DbSet<Person> Persons { get; set; } = null!;
	public DbSet<Transaction> Transactions { get; set; } = null!;

	private string DbPath { get; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Account>()
			.HasDiscriminator<string>("Type")
			.HasValue<SavingAccount>("SavingsAccount")
			.HasValue<CurrentAccount>("CurrentAccount");

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

		modelBuilder.Entity<Person>()
			.HasIndex(e => new { e.SocialSecurityNumber })
			.IsUnique();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite($"Data Source={DbPath}");
	}
}