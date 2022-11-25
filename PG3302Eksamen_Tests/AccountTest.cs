using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Controller;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class AccountHandlerTest {
	private BankContext _context = new();
	private bool _disposedValue; // To detect redundant calls

	[SetUp]
	public void CreateContextForInMemory() {
		var option = new DbContextOptionsBuilder<BankContext>()
			.UseInMemoryDatabase("test_db").Options;

		_context = new BankContext(option);
		_context.Database.EnsureDeleted();
		_context.Database.EnsureCreated();
	}

	protected virtual void Dispose(bool disposing) {
		if (!_disposedValue) {
			if (disposing) {
			}

			_disposedValue = true;
		}
	}

	public void Dispose() {
		Dispose(true);
	}



// A test that simlutates a change on a account name
	[Test]
	public void ChangeAccountNameTest() {
		AccountRepository accountRepository = new(_context);

		var currentAccount =
			new CurrentAccountFactory().InitializeAccount("Felleskonto", 1,
				"12345678912");

		accountRepository.Insert(currentAccount);
		accountRepository.ChangeAccountName(1, "Brukerkonto");
		var expectedAccountNumber = accountRepository.GetById(1).Name;

		Assert.That(expectedAccountNumber, Is.EqualTo("Brukerkonto"));
	}

	// a test that simulates a transfer between two different accounts
	[Test]
	public void TransferBetweenAccountsTest() {
		AccountRepository accountRepository = new(_context);
		AccountController controller = new();
		TransferController transferController = new(_context);
		var savingsAccount =
			new SavingsAccountFactory().InitializeAccount("Sparekonto", 1, "12345678912");
		var currentAccount = new CurrentAccountFactory().InitializeAccount("Brukskonto", 1, "123123324453");
		 accountRepository.Insert(savingsAccount);
		accountRepository.Update(savingsAccount);
		transferController.Execute(500, savingsAccount, currentAccount );
		Assert.That(accountRepository.GetById(2).Balance, Is.EqualTo(1500));
	}
	// a test that simulates retrieving all your account numbers
	[Theory]
	public void GetAllAccountNumbers() {
		AccountRepository accountRepository = new(_context);

		var savingsAccount =
			new SavingsAccountFactory().InitializeAccount("Sparekonto", 2, "12345678912");

		var currentAccount =
			new CurrentAccountFactory().InitializeAccount("Brukskonto", 2, "12345678901");

		accountRepository.Insert(currentAccount);
		accountRepository.Insert(savingsAccount);

		var actual = new List<string> {
			"12345678912",
			"12345678901"
		};

		CollectionAssert.AreEquivalent(accountRepository.GetAllAccountNumbers(), actual);
	}

	
}