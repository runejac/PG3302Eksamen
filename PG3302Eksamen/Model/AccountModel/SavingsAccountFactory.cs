namespace PG3302Eksamen.Model.AccountModel;

public class SavingsAccountFactory : AccountFactory {

    protected override SavingAccount CreateAccount(
        string name, int ownerId,
        string accountNumber) {
        return new SavingAccount {
            AccountNumber = accountNumber,
            Name = name,
            OwnerId = ownerId
        };
    }
}