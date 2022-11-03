namespace PG3302Eksamen.Model.AccountModel;

// The Creator class declares the factory method that is supposed to return
// an object of a Product class. The Creator's subclasses usually provide
// the implementation of this method.
internal abstract class AccountFactory {
    // Note that the Creator may also provide some default implementation of
    // the factory method.
    protected abstract Account CreateAccount(
        string name, int ownerId,
        string accountNumber);

    // Also note that, despite its name, the Creator's primary
    // responsibility is not creating products. Usually, it contains some
    // core business logic that relies on Product objects, returned by the
    // factory method. Subclasses can indirectly change that business logic
    // by overriding the factory method and returning a different type of
    // product from it.
    public Account InitializeAccount(
        string name, int ownerId,
        string accountNumber) {
        var account = CreateAccount(name, ownerId,
            accountNumber);
        return account;
    }
}