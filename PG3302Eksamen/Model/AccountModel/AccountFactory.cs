namespace PG3302Eksamen.Model.AccountModel;

// The Creator class declares the factory method that is supposed to return
// an object of a Product class. The Creator's subclasses usually provide
// the implementation of this method.
internal abstract class AccountFactory {
    // Note that the Creator may also provide some default implementation of
    // the factory method.
    protected abstract Account CreateAccount(int withdrawLimit, int interest,
        decimal balance, string name, Person owner,
        string accountNumber, DateTime dateOfCreation);

    // Also note that, despite its name, the Creator's primary
    // responsibility is not creating products. Usually, it contains some
    // core business logic that relies on Product objects, returned by the
    // factory method. Subclasses can indirectly change that business logic
    // by overriding the factory method and returning a different type of
    // product from it.
    public Account InitializeAccount(int withdrawLimit, int interest, decimal balance,
        string name, Person owner,
        string accountNumber, DateTime dateOfCreation) {
        var account = CreateAccount(withdrawLimit, interest, balance, name, owner,
            accountNumber, dateOfCreation);


        return account;
    }
}