using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class Tests {
	private bool disposedValue; // To detect redundant calls

	private BankContext context;

	
	[SetUp]
	public void CreateContextForInMemory() {
		var option = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase("test_db").Options;

		context = new BankContext(option);
		context.Database.EnsureDeleted();
		context.Database.EnsureCreated();
	}
    


	protected virtual void Dispose(bool disposing) {
		if (!disposedValue) {
			if (disposing) {
			}

			disposedValue = true;
		}
	}

	public void Dispose() {
		Dispose(true);
	}
	public void Setup() {
	}

	[Test]
	public void createPersonTest() {
		Person person = new();
		var personService = new PersonRepository(context);
		personService.Insert(person.CreatePerson(
			"Elaveien 5", 
			"Ola",
			"Normann",
			"123",
			"33445566",
			"04048944598",
			"olanormann@noreg.no"
			));
		
		Assert.That(personService.GetById(1).Id, Is.EqualTo(1));
	}

	[Test]
	public void addNewAccountTest() {
		SavingsAccountFactory save = new();
		Person person = new();
		var personService = new PersonRepository(context);
		var accountService = new AccountRepository(context);
		
		personService.Insert(person.CreatePerson(
				"Elaveien 5", 
				"Ola",
				"Normann",
				"123",
				"33445566",
				"04048944598",
				"olanormann@noreg.no"
			));
		context.SaveChanges();
		
		personService.AddNewAccount(save.InitializeAccount("sparekonto", 1, "89934989892134"));
		context.SaveChanges();
		Assert.That(accountService.GetById(1).OwnerId, Is.EqualTo(personService.GetById(accountService.GetById(1).OwnerId).Id));
	}
}