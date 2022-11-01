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

	// TODO RUNE holder på her, sånn tenker jeg Ui-klassen skal se ut
	public static void SucceedAddedToDbMessage(Account account) {
		Message($"Account added to your bank: {account.Name}", ConsoleColor.DarkGreen);
	}

	public static void InvalidInputMessage() {
		Message("Invalid input, try again", ConsoleColor.DarkRed);
	}
}