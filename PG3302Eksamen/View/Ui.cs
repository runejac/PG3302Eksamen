using PG3302Eksamen.Controller;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;

namespace PG3302Eksamen.View;

public static class Ui {
	// TODO Message skal være private etter hvert, men brukes i BankManager enn så lenge
	// TODO og skal kun brukes her
	// TODO, så skrives custom meldinger her og calles hvor de brukes tror jeg
	public static void Message(string message, ConsoleColor color) {
		Console.ForegroundColor = color;
		Console.WriteLine(message);
	}

	public static void MessageSameLine(string message, ConsoleColor color) {
		Console.ForegroundColor = color;
		Console.Write(message);
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

	public static void InvalidInputMessage(string? customMessage) {
		Message(customMessage ?? "Invalid input, try again.", ConsoleColor.DarkRed);
	}

	public static void WelcomeMessage() {
		var selectedChoice = PromptUtil.PromptSelectPrompt(
			" [cyan]Welcome to Bank Kristiania![/]",
			new[] { "Register", "Login" }
		);
		switch (selectedChoice) {
			case "Register":
				BankManager.RegisterNewPerson();
				break;
			case "Login":
				// TODO run code for authentication
				break;
		}
	}

	// TODO under er KUN hardkodet enn så lenge, skal brukes når bruker velger "Check balance".
	public static void OverViewOfAccounts() {
		var tableResult = new Table()
			.Border(TableBorder.Square)
			.BorderColor(Color.Green)
			.AddColumns("[white]Account name[/]", "[white]Balance[/]",
				"[white]Interest rate[/]", "[white]Withdrawal limit[/]");

		tableResult.AddRow(
			"[grey]" + "Sparekonto til kidsa" + "[/]",
			"[grey]" + "69 kr" + "[/]",
			"[grey]" + "15" + "[/]",
			"[grey]" + "20" + "[/]"
		);

		AnsiConsole.Render(tableResult);
	}

	public static void SuccessfullyRegistered(string name, int personId) {
		Message(
			$"Congratulations {name}, welcome to the Bank of Kristiania where your needs meets our competence!",
			ConsoleColor.Green);
		var selectedChoice = PromptUtil.PromptSelectPrompt("USER MENU",
			new[] {
				"Create a money account",
				"Pay bills or transfer money",
				"Check balance",
				"Log out"
			}
		);

		switch (selectedChoice) {
			case "Create a money account":
				BankManager.CreateBankAccount(personId);
				break;
			case "Pay bills or transfer money":
				// TODO run code for transactions
				break;
			case "Check balance":
				OverViewOfAccounts();
				break;
			case "Log out":
				// TODO run code for logging out
				break;
		}
	}
}