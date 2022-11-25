namespace PG3302Eksamen.Model.AccountModel;

public abstract class AccountFactory {

    protected abstract Account CreateAccount(
        string name, int ownerId,
        string accountNumber
    );
    
    public Account InitializeAccount(
        string name, int ownerId,
        string accountNumber) {
        var account = CreateAccount(name, ownerId,
            accountNumber);
        return account;
    }
}