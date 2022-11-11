using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Transfer : Transaction {
	public Transaction CreateTransfer(decimal amount, Account fromAccount,
		Account toAccount) {
		return new Transfer {
			Recipient = "self",
			Amount = amount,
			FromAccount = fromAccount.Id,
			ToAccount = toAccount.Id
		};
	}
}