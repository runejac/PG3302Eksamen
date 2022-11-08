using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.View;

public class UiTransaction {
	public void TransactionMenu(Ui ui, UiAccount uiAccount, UiBill bill) {
		var personAccounts = ui.UiPerson.GetAllAccounts().ToList();
		Account selectedFromAccount;
		Bill selectedBill;

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
			case "Make a payment":
				ui.ClearConsole();

				// person needs at least 1 account to pay a bill
				if (personAccounts.Count > 0) {
					selectedFromAccount =
						PromptUtil.PromptSelectForAccounts(
							"Which account do you want to use?",
							personAccounts);

					uiAccount.OverViewOfAccounts(selectedFromAccount, ui);

					var billsToPay = bill.UnpaidBills(ui.UiPerson.GetAllBills(ui.UiPerson.GetPerson()));

					selectedBill =
						PromptUtil.PromptSelectForBills("Which bill do you want to pay?",
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
						"You need at least 1 account to pay a bill. Create an account.",
						"red");
					ui.MainMenuAfterAuthorized();
				}

				break;
			case "Transfer between own accounts":
				ui.ClearConsole();

				// person needs at least 2 accounts to transfer between own accounts
				if (personAccounts.Count >= 2) {
					selectedFromAccount =
						PromptUtil.PromptSelectForAccounts("Transfer from account",
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
					TransactionMenu(ui, uiAccount, bill);
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
}