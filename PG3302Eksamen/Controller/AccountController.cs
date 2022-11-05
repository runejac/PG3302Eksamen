using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class AccountController {
    private readonly AccountRepository _accountRepository = new(new BankContext());
    private Account _account;
    private Person? _person;


    public void CreateSavingsAccount(string name,
        string accountNumber) {
        SavingsAccountFactory savingsAccountFactory = new();

        _account = savingsAccountFactory.InitializeAccount(name, _person.Id,
            accountNumber);
    }

    public void CreateCurrentAccount(string name,
        string accountNumber) {
        CurrentAccountFactory currentAccountFactory = new();

        _account = currentAccountFactory.InitializeAccount(name, _person.Id,
            accountNumber);
    }


    public void CreateBankAccount(Person? person) {
        _person = person;
    }

    public string GenerateBankAccountNumber() {
        var random = new Random();
        var numbers = random.NextInt64(00000000000, 99999999999);
        var accountNumberGenerated = numbers.ToString();

        // checking for existing account numbers
        foreach (var _ in _accountRepository.GetAllAccountNumbers()
                     .Where(accNr => accNr.Contains(accountNumberGenerated))) {
            // if it already exists, create a new one
            numbers = random.NextInt64(00000000000, 99999999999);
            accountNumberGenerated = numbers.ToString();
        }

        return accountNumberGenerated;
    }


    public Account SendAccountToDatabase() {
        PersonController personController = new();
        personController.AddAccount(_account);
        return _account;
    }
}