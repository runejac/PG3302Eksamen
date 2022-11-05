using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;

namespace PG3302Eksamen.View;

public class Ui {
	// TODO Message skal være private etter hvert, men brukes i BankManager enn så lenge
	// TODO og skal kun brukes her
	// TODO, så skrives custom meldinger her og calles hvor de brukes tror jeg

	private static UiPerson? _uiPerson = new();

	private static UiPerson? Person {
		get => _uiPerson;
		set => _uiPerson = value ?? throw new ArgumentNullException(nameof(value));
	}

	private static void ClearConsole() {
		Console.Clear();
	}

	private static void Message(string message, ConsoleColor color) {
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
			ConsoleColor.Blue
		);
	}

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
			"[cyan]Welcome to Bank Kristiania![/]",
			new[] { "Register", "Login", "Exit" }
		);
		switch (selectedChoice) {
			case "Register":
				Person?.CreatePerson();
				ClearConsole();
				MainMenuAfterAuthorized(Person.GetPerson());
				break;
			case "Login":
				//Person?.LogIn();
				if (Person != null && Person.LogIn()) {
					ClearConsole();
					MainMenuAfterAuthorized(Person.GetPerson());
				}
				else {
					ClearConsole();
					InvalidInputMessage("Wrong credentials, try again!");
					WelcomeMessage();
				}

				break;
			case "Exit":
				Message("Good bye, hope to see you soon!", ConsoleColor.Blue);
				Environment.Exit(0);
				break;
		}
	}

	private static void OverViewOfAccounts() {
		ClearConsole();
		var printAccountDetails = Person!.GetAllAccounts();

		var tableResult = new Table()
			.Title("[deeppink2]Overview of your accounts[/]")
			.Border(TableBorder.Rounded)
			.BorderColor(Color.Green)
			.AddColumns("[white]Account name[/]", "[white]Account number[/]",
				"[white]Balance[/]",
				"[white]Interest rate[/]", "[white]Withdrawal limit[/]");

		foreach (var account in printAccountDetails) {
			tableResult.AddRow(
				"[grey]" + $"{account.Name}" + "[/]",
				"[grey]" + $"{account.AccountNumber}" + "[/]",
				"[grey]" + $"{account.Balance} kr" + "[/]",
				"[grey]" + $"{account.Interest}" + "[/]",
				"[grey]" + $"{account.WithdrawLimit}" + "[/]"
			);
		}

		AnsiConsole.Render(tableResult);
		GoBackToMainMenu();
	}

	private static void OverViewOfBills() {
		ClearConsole();
		var allBills = Person.GetAllBills();

		var tableResult = new Table()
			.Title("[deeppink2]Overview of your bills[/]")
			.Border(TableBorder.MinimalHeavyHead)
			.BorderColor(Color.Green)
			.AddColumns("[white]Due date[/]", "[white]Recipient[/]",
				"[white]Account number[/]",
				"[white]KID/message[/]",
				"[white]Status[/]", "[white]Amount[/]");

		foreach (var bill in allBills) {
			tableResult.AddRow(
				"[grey]" + $"{bill.DueDate}" + "[/]",
				"[grey]" + $"{bill.Recipient}" + "[/]",
				"[grey]" + $"{bill.AccountNumber}" + "[/]",
				"[grey]" + $"{bill.MessageField}" + "[/]",
				"[grey]" + $"{bill.Status}" + "[/]",
				"[grey]" + $"{bill.Amount} ,-" + "[/]"
			);
		}

		AnsiConsole.Render(tableResult);

		GoBackToMainMenu();
	}

	private static void UserAccountDetails() {
		var printUserDetails = Person!.GetPerson();
		var tableResult = new Table()
			.Border(TableBorder.Square)
			.BorderColor(Color.Green)
			.AddColumns("[white]Name[/]", "[white]Address[/]",
				"[white]Email[/]", "[white]Phone number[/]");

		tableResult.AddRow(
			"[grey]" + $"{printUserDetails.FirstName} {printUserDetails.LastName}" +
			"[/]",
			"[grey]" + $"{printUserDetails.Address}" + "[/]",
			"[grey]" + $"{printUserDetails.Email}" + "[/]",
			"[grey]" + $"{printUserDetails.PhoneNumber}" + "[/]"
		);

		AnsiConsole.Render(tableResult);
		GoBackToMainMenu();
	}

	private static void GoBackToMainMenu() {
		var selectedChoice = PromptUtil.PromptSelectPrompt("MENU",
			new[] {
				"Back"
			}
		);
		switch (selectedChoice) {
			case "Back":
				ClearConsole();
				MainMenuAfterAuthorized(Person.GetPerson());
				break;
		}
	}

	private static void MainMenuAfterAuthorized(Person person) {
		if (person == null) {
			throw new ArgumentNullException(nameof(person));
		}

		/*var image = new CanvasImage("../../../Assets/money.jpg");
		image.MaxWidth(32);
		image.BilinearResampler();
		AnsiConsole.Write(image);*/

		Message(
			$"Greetings {person.FirstName}, welcome to the Bank of Kristiania where your needs meets our competence!",
			ConsoleColor.Green);
		var selectedChoice = PromptUtil.PromptSelectPrompt("MAIN MENU",
			new[] {
				"Create a money account",
				"Pay bills or transfer money",
				"Display all bills",
				"Display all accounts",
				"Display user details",
				"Log out"
			}
		);

		switch (selectedChoice) {
			case "Create a money account":
				AccountController accountController = new();
				accountController.CreateBankAccount(person.Id);
				GoBackToMainMenu();
				break;
			case "Pay bills or transfer money":
				// TODO run code for transactions
				break;
			case "Display all bills":
				OverViewOfBills();
				break;
			case "Display all accounts":
				ClearConsole();
				OverViewOfAccounts();
				break;
			case "Display user details":
				ClearConsole();
				UserAccountDetails();
				break;
			case "Log out":
				ClearConsole();
				WelcomeMessage();
				Person = null;
				break;
		}
	}
}