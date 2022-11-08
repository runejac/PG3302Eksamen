using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Transfer : Transaction {
	public new decimal Amount { get; set; }
	public int Receipt { get; set; }
	public new int Id { get; set; }

	public Transaction CreateTransfer(decimal amount, Account fromAccount,
		Account toAccount) {
		return new Transfer {
			Amount = amount,
			FromAccount = fromAccount,
			ToAccount = toAccount
		};
	}

	public Transaction
		CreateBillPayment(decimal amount, Account fromAccount, Bill toBill) {
		return new Transfer {
			Amount = amount,
			FromAccount = fromAccount,
			ToBill = toBill
		};
	}
}