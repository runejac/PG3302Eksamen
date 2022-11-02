using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Transfer : Transaction {
    public new decimal Amount { get; set; }

    public int Receipt { get; set; }

    public new int Id { get; set; }

    public Transfer CreateTransfer(Account toAccount, Account fromAccount, decimal amount) {
        return new Transfer {
            ToAccount = toAccount,
            FromAccount = fromAccount,
            Amount = amount
        };
    }
}