using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class BillController {
	private readonly AccountController _ac = new();
	private readonly AccountRepository _accountRepository = new(new BankContext());
	private readonly Bill _bill = new();
	private readonly BillRepository _billRepository = new(new BankContext());
	private readonly BankContext _context = new();

	private readonly Person _person = new();

	public Person GetPerson() {
		return _person;
	}

	public List<Bill> GetAllBills() {
		return _billRepository.GetSortedByOwner(GetPerson().Id).ToList();
	}


	public Bill GenerateBills(int id) {
		return _bill.CreateBill(_ac.GenerateBankAccountNumber(_accountRepository),
			"TestPerson",
			"Gjelder parkingsbot",
			300,
			BillStatusEnum.NOTPAID,
			DateTime.Now,
			id);
	}
}