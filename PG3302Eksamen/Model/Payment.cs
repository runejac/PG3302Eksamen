using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Payment : Transaction {

	public Transaction CreatePayment(string selectedBillRecipient, int toAccount,
		Account fromAccount, decimal amount) {
		return new Payment {
			Recipient = selectedBillRecipient,
			ToAccount = toAccount,
			FromAccount = fromAccount.Id,
			Amount = amount
		};
	}
}