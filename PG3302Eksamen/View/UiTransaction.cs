using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;

namespace PG3302Eksamen.View;

public class UiTransaction {


	// TODO did not make it in time to show transactions, but stored properly in DB
	/*public void OverViewOfTransactions(Ui ui) {
		ui.ClearConsole();
		var allBills = ui.UiPerson.GetAllBills(ui.UiPerson.GetPerson());

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
				"[grey]" + $"{bill.ToAccount}" + "[/]",
				"[grey]" + $"{bill.MessageField}" + "[/]",
				"[grey]" + $"{bill.Status}" + "[/]",
				"[grey]" + $"{bill.Amount} ,-" + "[/]"
			);
		}

		AnsiConsole.Render(tableResult);

		ui.GoBackToMainMenu();
	}*/
	
	
	public void TransactionMenu(Ui ui, UiAccount uiAccount, UiBill bill) {
		var personAccounts = ui.UiPerson.GetAllAccounts().ToList();

		PromptUtil.PromptAssertion(
			"Do you wish to make a payment or transfer between your own accounts?",
			"green");

		var selectedChoice = PromptUtil.PromptSelect("Transaction",
			new[] {
				"Make a payment",
				"Transfer between own accounts",
				"[red]Back[/]"
			}
		);

		switch (selectedChoice) {
			// person needs at least 2 accounts to transfer between own accounts
			case "Make a payment":
				ui.ClearConsole();
				if (personAccounts.Count > 0) {
					MakePayment(ui, uiAccount, bill, personAccounts);
				}
				else {
					PromptUtil.PromptAssertion(
						"You need at least 1 account to pay a bill. Create an account.",
						"red");
					ui.MainMenuAfterAuthorized();
				}

				break;
			case "Transfer between own accounts":
				ui.ClearConsole();
				if (personAccounts.Count >= 2) {
					TransferToOwnAccounts(ui, uiAccount, bill, personAccounts);
				}
				else {
					PromptUtil.PromptAssertion(
						"You need at least 2 accounts to transfer money between your own accounts. Create account(s).",
						"red");
					ui.MainMenuAfterAuthorized();
				}

				break;
			case "[red]Back[/]":
				ui.ClearConsole();
				ui.MainMenuAfterAuthorized();

				break;
		}
	}


	private void TransferToOwnAccounts(Ui ui, UiAccount uiAccount, UiBill bill,
		List<Account> personAccounts) {
		var selectedFromAccount = PromptUtil.PromptSelectForAccounts(
			"Transfer from account",
			personAccounts);

		uiAccount.OverViewOfAccounts(selectedFromAccount, ui);

		var amount = PromptUtil.PromptAmountInput("Transfer amount: ",
			"Not enough balance", selectedFromAccount);


		if (amount.Equals(0)) {
			ui.ClearConsole();
			ui.MainMenuAfterAuthorized();
		}

		var listOfAvailableAccountsTo = personAccounts.Where(account =>
			!account.Equals(selectedFromAccount));

		var selectedToAccount =
			PromptUtil.PromptSelectForAccounts("Transfer to account",
				listOfAvailableAccountsTo);

		uiAccount.Calculate(amount, selectedFromAccount, selectedToAccount);
		PromptUtil.PromptAssertion(
			$"Successfully transferred {amount} kr from {selectedFromAccount.Name} to {selectedToAccount.Name}",
			"green");

		TransactionMenu(ui, uiAccount, bill);
	}


	private void MakePayment(Ui ui, UiAccount uiAccount, UiBill bill,
		List<Account> personAccounts) {
		if (personAccounts.Count > 0) {
			var selectedFromAccount =
				PromptUtil.PromptSelectForAccounts(
					"Which account do you want to use?",
					personAccounts);

			uiAccount.OverViewOfAccounts(selectedFromAccount, ui);

			var billsToPay =
				bill.UnpaidBills(
					ui.UiPerson.GetAllBills(ui.UiPerson.GetPerson()));

			if (billsToPay.Any()) {
				var selectedBill =
					PromptUtil.PromptSelectForBills(
						"Which bill do you want to pay?",
						billsToPay);

				if (selectedBill.Amount <= selectedFromAccount.Balance) {
					bill.Calculate(selectedFromAccount, selectedBill);
					PromptUtil.PromptAssertion(
						$"Successfully paid to {selectedBill.Recipient} with the amount of {selectedBill.Amount} kr",
						"green");

					TransactionMenu(ui, uiAccount, bill);
				}
				else {
					PromptUtil.PromptAssertion(
						"Not enough money in account to make the payment.",
						"red");
					TransactionMenu(ui, uiAccount, bill);
				}
			}
			else {
				PromptUtil.PromptAssertion(
					"No bills found, up-to-date on payments!", "green");
				ui.MainMenuAfterAuthorized();
			}
		}
		else {
			PromptUtil.PromptAssertion(
				"You need at least 1 account to pay a bill. Create an account.",
				"red");
			ui.MainMenuAfterAuthorized();
		}
	}
}