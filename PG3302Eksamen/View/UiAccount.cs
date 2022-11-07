using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.View;

public class UiAccount {
	private readonly AccountController _accountController = new();
	private readonly TransferController _transferController = new();
	private Person _person;
	private Ui _ui;


	public void CreateBankAccountFor(Person person) {
		_person = person;
		_accountController.CreateBankAccount(_person);
	}

	public void AskUserWhatTypeOfAccountToBeMade() {
		var accountTypeAnswer = PromptUtil.PromptSelect(
			"Do you want it to be a savings account or a current account?",
			new[] { "Current account", "Savings account", "[red]Back[/]" });

		switch (accountTypeAnswer) {
			case "Current account": {
				var accountName = AskAccountName(accountTypeAnswer);
				_accountController.CreateCurrentAccount(accountName,
					_accountController.GenerateBankAccountNumber());
				var savedAccount = _accountController.SendAccountToDatabase();
				SucceedAddedToDbMessage(savedAccount);
				break;
			}
			case "Savings account": {
				var accountName = AskAccountName(accountTypeAnswer);
				_accountController.CreateSavingsAccount(accountName,
					_accountController.GenerateBankAccountNumber());
				var savedAccount = _accountController.SendAccountToDatabase();
				SucceedAddedToDbMessage(savedAccount);
				break;
			}
			case "[red]Back[/]":
				// TODO mulig denne er feil her, men funker å gå tilbake
				_ui = new Ui();
				_ui.ClearConsole();
				_ui.MainMenuAfterAuthorized();
				break;
		}
	}

	private string AskAccountName(string accountTypeAnswer) {
		return PromptUtil.PromptQuestion(
			$"You've chosen to create an [blue]{accountTypeAnswer}[/]\n" +
			$"What do you want to name your [blue]{accountTypeAnswer}[/]?",
			"Invalid choice");
	}

	public static void SucceedAddedToDbMessage(Account account) {
		PromptUtil.PromptAssertion(
			$"{account.Name} was added to your bank account\n" +
			$"with interest rate at: {account.Interest}%\n" +
			$"{(account.WithdrawLimit > 0 ? $"and savings account has a yearly withdraw limit at {account.WithdrawLimit}" : "")}",
			"green");
	}


	// TODO: Cross-controller calls should be avoided?
	private void OverViewOfAccounts() {
		//  var printAccountDetails = Person.GetAllAccounts();

		/*var tableResult = new Table()
		    .Border(TableBorder.Square)
		    .BorderColor(Color.Green)
		    .AddColumns("[white]Account name[/]", "[white]Account number[/]",
		        "[white]Balance[/]",
		        "[white]Interest rate[/]", "[white]Withdrawal limit[/]");

		foreach (var account in printAccountDetails)
		    tableResult.AddRow(
		        "[grey]" + $"{account.Name}" + "[/]",
		        "[grey]" + $"{account.AccountNumber}" + "[/]",
		        "[grey]" + $"{account.Balance} kr" + "[/]",
		        "[grey]" + $"{account.Interest}" + "[/]",
		        "[grey]" + $"{account.WithdrawLimit}" + "[/]"
		    );

		AnsiConsole.Render(tableResult);*/
	}


	public void Calculate(decimal amount, Account selectedFromAccount,
		Account selectedToAccount) {
		_transferController.Execute(amount, selectedFromAccount, selectedToAccount);
	}
}