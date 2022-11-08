using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using Spectre.Console;

namespace PG3302Eksamen.View;

public class UiBill {
	private readonly List<string> _billOptions = new();
	private readonly TransferController _transferController = new();
	private Bill _bill;
	private IEnumerable<Bill> _bills;

	public void SelectBillToPay(string billToPayAccountNumber) {
		_bill = _bills.Single(bill => bill.AccountNumber == billToPayAccountNumber);
	}

	public IEnumerable<Bill> UnpaidBills(IEnumerable<Bill> unpaidBills) {
		return _bills = unpaidBills.Where(bill => bill.Status == BillStatusEnum.Notpaid);
	}


	public void Calculate(Account selectedFromAccount, Bill selectedBill) {
		_transferController.ExecuteBillPayment(selectedFromAccount, selectedBill);
	}

	public void OverViewOfBills(Ui ui) {
		ui.ClearConsole();
		var allBills = ui.UiPerson.GetAllBills();

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

		ui.GoBackToMainMenu();
	}
}