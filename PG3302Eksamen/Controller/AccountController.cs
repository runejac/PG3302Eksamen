using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Controller;

public class AccountController {
    private Account Account;

    public void CreateSavingsAccount(string name, int ownerId,
    string accountNumber) {
        SavingsAccountFactory savingsAccountFactory = new();

        Account = savingsAccountFactory.InitializeAccount( name, ownerId,
            accountNumber);
    }
}