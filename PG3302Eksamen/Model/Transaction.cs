using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public abstract class Transaction {
	public int Id { get; set; }
	public decimal Amount { get; set; }

	public Account FromAccount { get; set; }

	public Account ToAccount { get; set; }
	public Bill ToBill { get; set; }
}