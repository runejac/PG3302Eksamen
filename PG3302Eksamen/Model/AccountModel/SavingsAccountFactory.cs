// Concrete Creators override the factory method in order to change the
// resulting product's type.

namespace A_Team.Core.Model.AccountModel;

internal class SavingsAccountFactory : AccountFactory {
    // Note that the signature of the method still uses the abstract product
    // type, even though the concrete product is actually returned from the
    // method. This way the Creator can stay independent of concrete product
    // classes.


    protected override SavingAccount CreateAccount(int withdrawLimit, int interest,
        decimal balance,
        string name, Person owner,
        string accountNumber,
        DateTime dateOfCreation) {
        return new SavingAccount {
            WithdrawLimit = withdrawLimit,
            AccountNumber = accountNumber,
            Balance = balance,
            Interest = interest,
            Name = name,
            Owner = owner,
            DateOfCreation = dateOfCreation
        };
    }
}