using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Controller;

public class AccountController {
    private Account Account;

    public void CreateSavingsAccount(int withdrawLimit, int interest,
        decimal balance,
        string name, Person owner,
        string accountNumber,
        DateTime dateOfCreation) {
        SavingsAccountFactory savingsAccountFactory = new();

        Account = savingsAccountFactory.InitializeAccount(withdrawLimit, interest,
            balance,
            name, owner,
            accountNumber,
            dateOfCreation);
    }
}