using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Transfer : Transaction {
    public new decimal Amount { get; set; }
    public new int Id { get; set; }

    public Transaction CreateTransfer(decimal amount, Account fromAccount,
        Account toAccount) {
        return new Transfer {
            Amount = amount,
            FromAccount = fromAccount.Id,
            ToAccount = toAccount.Id
        };
    }
}