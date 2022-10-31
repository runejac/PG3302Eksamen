// Concrete Creators override the factory method in order to change the
// resulting product's type.

namespace A_Team.Core.Model.AccountModel;

internal class CurrentAccountFactory : AccountFactory {
	// Note that the signature of the method still uses the abstract product
	// type, even though the concrete product is actually returned from the
	// method. This way the Creator can stay independent of concrete product
	// classes.


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