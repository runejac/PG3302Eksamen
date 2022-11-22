namespace PG3302Eksamen.Model.AccountModel;

public class CurrentAccountFactory : AccountFactory {
    
    protected override CurrentAccount CreateAccount(
        string name, int ownerId,
        string accountNumber) {
        return new CurrentAccount {
            AccountNumber = accountNumber,
            Name = name,
            OwnerId = ownerId
        };
    }
}