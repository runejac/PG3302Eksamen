using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.Controller;

public class BillController {
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly Bill _bill = new();
	private readonly BillRepository _billRepository = new(new BankContext());
	private readonly Payment _payment = new();

	private readonly TransactionRepository
		_transactionRepository = new(new BankContext());

	private List<string> _billRecipients;


	private void AddBillRecipients() {
		_billRecipients = new List<string> {
			"Rent to Jack Sparrow",
			"PayPal",
			"Amazon.com",
			"Netflix AS",
			"Foodora AS",
			"Electricity AS",
			"Spotify account",
			"Kondomeriet AS",
			"Mamma"
		};
	}

	private string UseRandomRecipient() {
		AddBillRecipients();
		var random = new Random();
		var i = 0;
		var next = random.Next(_billRecipients.Count);

		foreach (var recipient in _billRecipients) {
			if (i == next) {
				return recipient;
			}

			i++;
		}

		return "";
	}

	private static string GenerateRandomKidNumber() {
		var random = new Random();
		var numbers = random.NextInt64(0000000000, 9999999999);
		var accountNumberGenerated = numbers.ToString();

		// make an KID number / message
		return "7777" + accountNumberGenerated;
	}


	public Bill GenerateBills(Person person, Account account) {
		return _bill.CreateBill(
			account,
			UseRandomRecipient(),
			GenerateRandomKidNumber(),
			AmountGeneratorUtil.GenerateAmount(50, 700),
			BillStatusEnum.Notpaid,
			DateTime.Today.AddDays(14),
			person.Id);
	}


	public void ExecuteBillPayment(Account selectedFromAccount, Bill selectedBill) {
		var transaction = _payment.CreatePayment(selectedBill.Recipient,
			selectedBill.ToAccount, selectedFromAccount, selectedBill.Amount);


		_transactionRepository.ProcessTransaction(transaction);


		selectedFromAccount.Balance -= selectedBill.Amount;
		selectedBill.Status = BillStatusEnum.Paid;

		_billRepository.Update(selectedBill);
		_accountRepository.Update(selectedFromAccount);
	}
	
	public void BillGenerator(Person person) {
		var adminAccount = _accountRepository.GetById(1);

		_billRepository.Insert(GenerateBills(person, adminAccount));
	}
}