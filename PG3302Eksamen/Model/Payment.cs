using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model; 

public class Payment : Transaction {
    public new decimal Amount { get; set; }

    public int Receipt { get; set; }

    public new int Id { get; set; }

    public Payment CreatePayment(Account toAccount, Account fromAccount, decimal amount) {
        return new Payment {
            ToAccount = toAccount,
            FromAccount = fromAccount,
            Amount = amount
        };
    }
}