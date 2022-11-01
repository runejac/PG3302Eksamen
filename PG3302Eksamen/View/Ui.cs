using A_Team.Core.Model.AccountModel;

namespace PG3302Eksamen.View;

public static class Ui {
	// TODO Message skal være private etter hvert, men brukes i BankManager enn så lenge
	// TODO og skal kun brukes her
	// TODO, så skrives custom meldinger her og calles hvor de brukes tror jeg
	public static void Message(string message, ConsoleColor color) {
		Console.ForegroundColor = color;
		Console.WriteLine(message);
	}

	public static void AskUserWhatTypeOfAccountToBeMade() {
		Message("Do you want it to be a savings account or a current account?\n" +
		        "1. savings account\n" +
		        "2. current account", ConsoleColor.Blue);
	}

	public static void ChosenAccountType(Account account) {
		Message(
			$"You've chosen to create an {account.GetAccountType()}\n" +
			$"What do you want to name your {account.GetAccountType()}?",
			ConsoleColor.Blue);
	}


	// TODO RUNE holder på her, sånn tenker jeg Ui-klassen skal se ut
	public static void SucceedAddedToDbMessage(Account account) {
		Message($"{account.Name} was added to your bank account\n" +
		        $"with interest rate at {account.Interest}%\n" +
		        $"{(account.WithdrawLimit > 0 ? $"and savings account has a yearly withdraw limit at {account.WithdrawLimit}" : "")}"
			,
			ConsoleColor.DarkGreen);
	}

	public static void InvalidInputMessage() {
		Message("Invalid input, try again", ConsoleColor.DarkRed);
	}
}