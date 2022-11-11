using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Deposit : Transaction {
    
    public Transaction CreateDeposit(Account toAccount, Account fromAccount, decimal amount) {
        return new Deposit {
            ToAccount = toAccount.Id,
            FromAccount = fromAccount.Id,
            Amount = amount
        };
    }
}