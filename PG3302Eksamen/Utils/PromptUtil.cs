using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using Spectre.Console;

namespace PG3302Eksamen.Utils;

public static class PromptUtil {
	public static bool PromptConfirmation(string text) {
		return AnsiConsole.Confirm("[green]" + text + "[/]");
	}

	public static string PromptSelect(string? title, string[] questions) {
		return AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title(title)
				.PageSize(10)
				.AddChoices(questions));
	}

	public static Bill PromptSelectForBills(string? title, IEnumerable<Bill> questions) {
		return AnsiConsole.Prompt(
			new SelectionPrompt<Bill>()
				.Title(title)
				.PageSize(10)
				.AddChoices(questions.Select(q => q))
				.UseConverter(q => q.Recipient + " | Amount: " + q.Amount));
	}

	public static Account PromptSelectForAccounts(string transferFromAccount,
		IEnumerable<Account> personAccounts) {
		return AnsiConsole.Prompt(
			new SelectionPrompt<Account>()
				.Title(transferFromAccount)
				.PageSize(10)
				.AddChoices(personAccounts.Select(q => q))
				.UseConverter(q => q.Name + " | Balance: " + q.Balance));
	}

	public static string PromptPassword(string question) {
		return AnsiConsole.Prompt(
			new TextPrompt<string>(question)
				.PromptStyle("grey50")
				.Secret());
	}

	public static string PromptEmail(string question, string error) {
		var inputFromUser = AnsiConsole.Prompt(
			new TextPrompt<string>(question)
				.Validate(input
					=> input.Contains('@')
						? ValidationResult.Success()
						: ValidationResult.Error($"[red]{error}[/]")));

		inputFromUser = TrimUtil.TrimInput(inputFromUser);
		return inputFromUser;
	}


	public static string PromptPhoneNr(string question, string error) {
		var inputFromUser = AnsiConsole.Prompt(
			new TextPrompt<string>(question)
				.Validate(input
					=> input.All(char.IsDigit)
						? ValidationResult.Success()
						: ValidationResult.Error("[red]" + error + "[/]"))
		);

		inputFromUser = TrimUtil.TrimInput(inputFromUser);
		return inputFromUser;
	}

	public static string PromptQuestion(string question, string error) {
		var inputFromUser = AnsiConsole.Prompt(
			new TextPrompt<string>(question)
				.Validate(input
					=> !string.IsNullOrEmpty(input)
						? ValidationResult.Success()
						: ValidationResult.Error("[red]" + error + "[/]"))
		);

		inputFromUser = TrimUtil.TrimInput(inputFromUser);
		return inputFromUser;
	}

	public static decimal PromptAmountInput(string question, string error,
		Account account) {
		var result = AnsiConsole.Prompt(new TextPrompt<decimal>(question));

		if (account.Balance >= result) {
			return result;
		}

		PromptAssertion(error, "red");

		if (PromptConfirmation("Try again?")) {
			return PromptAmountInput(question, error, account);
		}

		return 0;
	}

	// TODO: Does not seem to interpolate correctly :(
	public static void PromptAssertion(string assertion, string color) {
		AnsiConsole.MarkupLineInterpolated($"[{color}]{assertion}[/]");
	}
}