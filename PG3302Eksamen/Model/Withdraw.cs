using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Withdraw : Transaction {
    public new int Id { get; set; }

    public Withdraw CreateWithdraw(Account toAccount, Account fromAccount, decimal amount) {
        return new Withdraw {
            ToAccount = toAccount,
            FromAccount = fromAccount,
            Amount = amount
        };
    }
}