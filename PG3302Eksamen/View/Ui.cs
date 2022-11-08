using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;

namespace PG3302Eksamen.View;

public class Ui {
	private readonly UiAccount _uiAccount = new();
	private readonly UiBill _uiBill = new();
	private Person _person;

	public UiPerson UiPerson { set; get; }


	public void ClearConsole() {
		Console.Clear();
	}

	private void Message(string message, ConsoleColor color) {
		Console.ForegroundColor = color;
		Console.WriteLine(message);
	}

	public void WelcomeMessage() {
		var selectedChoice = PromptUtil.PromptSelect(
			"[cyan]Welcome to Bank Kristiania![/]",
			new[] { "Register", "Login", "[red]Exit[/]" }
		);
		switch (selectedChoice) {
			case "Register":
				UiPerson = new UiPerson();
				UiPerson.CreatePerson();
				_person = UiPerson.GetPerson();
				ClearConsole();
				MainMenuAfterAuthorized();
				break;
			case "Login":
				UiPerson = new UiPerson();
				try {
					_person = UiPerson.LogIn();
					ClearConsole();
					MainMenuAfterAuthorized();
				}
				catch (Exception e) {
					Message("Wrong credentials, try again or register.",
						ConsoleColor.Red);
					Thread.Sleep(3000);
					UiPerson = null;
					ClearConsole();
					WelcomeMessage();
				}

				break;
			case "[red]Exit[/]":
				Message("Good bye, hope to see you soon!", ConsoleColor.Blue);
				Environment.Exit(0);
				break;
		}
	}

	// TODO: Move to UiAccount

	private void OverViewOfBills() {
		ClearConsole();
		var allBills = UiPerson.GetAllBills();

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


	public void GoBackToMainMenu() {
		var selectedChoice = PromptUtil.PromptSelect("",
			new[] {
				"[red]Back[/]"
			}
		);
		switch (selectedChoice) {
			case "[red]Back[/]":
				ClearConsole();
				MainMenuAfterAuthorized();
				break;
		}
	}

	public void MainMenuAfterAuthorized() {
		Message(
			$"Greetings {_person?.FirstName}, welcome to the Bank of Kristiania where your needs meets our competence!",
			ConsoleColor.Green);
		var selectedChoice = PromptUtil.PromptSelect("MAIN MENU",
			new[] {
				"Create an account",
				"Pay bills or transfer money",
				"Display all bills",
				"Display all accounts",
				"Display user details",
				"[red]Log out[/]"
			}
		);

		switch (selectedChoice) {
			case "Create an account":
				ClearConsole();
				_uiAccount.CreateBankAccountFor(_person);
				_uiAccount.AskUserWhatTypeOfAccountToBeMade();
				MainMenuAfterAuthorized();
				break;
			case "Pay bills or transfer money":
				ClearConsole();
				TransactionMenu();
				break;
			case "Display all accounts":
				ClearConsole();
				_uiAccount.OverViewOfAccounts(null, this);
				GoBackToMainMenu();
				break;
			case "Display all bills":
				OverViewOfBills();
				break;
			case "Display user details":
				ClearConsole();
				UiPerson!.UserAccountDetails();
				GoBackToMainMenu();
				break;
			case "[red]Log out[/]":
				Message(
					$"You are now logged out, {_person?.FirstName}.",
					ConsoleColor.Blue);
				Thread.Sleep(3000);
				ClearConsole();
				WelcomeMessage();
				_person = null;
				break;
		}
	}

	private void TransactionMenu() {
		var personAccounts = UiPerson.GetAllAccounts().ToList();
		Account selectedFromAccount;
		Bill selectedBill;

		Message(
			"Do you wish to make a payment or transfer between your own accounts?",
			ConsoleColor.Green);
		var selectedChoice = PromptUtil.PromptSelect("Transaction",
			new[] {
				"Make a payment",
				"Transfer between own accounts",
				"[red]Back[/]"
			}
		);

		switch (selectedChoice) {
			case "Make a payment":
				ClearConsole();

				// person needs at least 1 account to pay a bill
				if (personAccounts.Count > 0) {
					selectedFromAccount =
						PromptUtil.PromptSelectForAccounts(
							"Which account do you want to use?",
							personAccounts);

					_uiAccount.OverViewOfAccounts(selectedFromAccount, this);

					var billsToPay = _uiBill.UnpaidBills(UiPerson.GetAllBills());

					selectedBill =
						PromptUtil.PromptSelectForBills("Which bill do you want to pay?",
							billsToPay);

					// TODO sjekke at selectedBill.Amount ikke er større enn selectedFromAccount.Amount

					if (selectedBill.Amount <= selectedFromAccount.Balance) {
						_uiBill.Calculate(selectedFromAccount, selectedBill);
						Message(
							$"Successfully paid to {selectedBill.Recipient} with the amount of {selectedBill.Amount} kr",
							ConsoleColor.Green);

						TransactionMenu();
					}
					else {
						Message("Not enough money in account to make the payment.",
							ConsoleColor.Red);
						TransactionMenu();
					}
				}
				else {
					Message(
						"You need at least 1 account to pay a bill. Create an account.",
						ConsoleColor.Red);
					MainMenuAfterAuthorized();
				}


				break;
			case "Transfer between own accounts":
				ClearConsole();

				// person needs at least 2 accounts to transfer between own accounts
				if (personAccounts.Count >= 2) {
					selectedFromAccount =
						PromptUtil.PromptSelectForAccounts("Transfer from account",
							personAccounts);

					_uiAccount.OverViewOfAccounts(selectedFromAccount, this);

					var amount = PromptUtil.PromptAmountInput("Transfer amount: ",
						"Not enough balance", selectedFromAccount);


					if (amount.Equals(0)) {
						ClearConsole();
						MainMenuAfterAuthorized();
					}

					var listOfAvailableAccountsTo = personAccounts.Where(account =>
						!account.Equals(selectedFromAccount));

					var selectedToAccount =
						PromptUtil.PromptSelectForAccounts("Transfer to account",
							listOfAvailableAccountsTo);

					_uiAccount.Calculate(amount, selectedFromAccount, selectedToAccount);
					TransactionMenu();
				}
				else {
					Message(
						"You need at least 2 accounts to transfer money between your own accounts. Create account(s).",
						ConsoleColor.Red);
					MainMenuAfterAuthorized();
				}


				break;
			case "[red]Back[/]":
				ClearConsole();
				MainMenuAfterAuthorized();
				break;
		}
	}
}