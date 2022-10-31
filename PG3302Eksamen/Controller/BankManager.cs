using A_Team.Core.Model;
using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Controller;

public class BankManager : IBankManager {
	private static BankManager _instance;

	private BankManager() {
	}

	public void Run() {
		getInstance();
	}

	public static BankManager getInstance() {
		if (_instance == null) _instance = new BankManager();
		return _instance;
	}

	public Account CreateBankAccount(Person person) {
		var random = new Random();
		var numbers = random.NextInt64(00000000000, 99999999999);
		var accountNumberGenerated = numbers.ToString();

		// TODO på en eller annen måte kunne sjekke om
		// TODO accountNumberGenerated eksisterer fra før i DB
		if (accountNumberGenerated ==
		    "DUMMY | MÅ HA INN QUERY FOR DB SJEKK PÅ KONTONUMMER") {
			// rerun random number generator again
			numbers = random.NextInt64(00000000000, 99999999999);
			accountNumberGenerated = numbers.ToString();
		}

		return new Account(accountNumberGenerated, person);
	}
	

	public void DepositMoney(Person person, Account fromAccount, Account toAccount,
		decimal amount) {
	}
}