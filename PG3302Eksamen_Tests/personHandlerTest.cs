using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class Tests {
	private bool disposedValue; // To detect redundant calls

	private BankContext _context = new();

	
	[SetUp]
	public void CreateContextForInMemory() {
		var option = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase("test_db").Options;

		
		_context = new BankContext(option);
		_context.Database.EnsureDeleted();
		_context.Database.EnsureCreated();
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
	public void CreatePersonTest() {
		
		Person person = new();
		var personService = new PersonRepository(_context);
		personService.Insert(person.CreatePerson(
			"Elaveien 5", 
			"Ola",
			"Normann",
			"123",
			"33445566",
			"04048944598",
			"olanormann@noreg.no"
			));
		_context.SaveChanges();
		Assert.That(personService.GetById(1).Id, Is.EqualTo(1));
	}

	[Test]
	public void DeletePersonTest() {
		var personService = new PersonRepository(_context);
		Person person = new();
		var createdPerson = person.CreatePerson(
			"Elaveien 5",
			"Ola",
			"Normann",
			"123",
			"33445566",
			"04048944598",
			"olanormann@noreg.no"
		);
		
		personService.Insert(createdPerson);
		personService.Remove(createdPerson);
	
		
		Assert.That(personService.GetAll().ToList().Count(), Is.EqualTo(0));
	}

	[Test]
	public void AddNewAccountTest() {
		SavingsAccountFactory save = new();
		Person person = new();
		var personService = new PersonRepository(_context);
		var accountService = new AccountRepository(_context);
		
		personService.Insert(person.CreatePerson(
				"Elaveien 5", 
				"Ola",
				"Normann",
				"123",
				"33445566",
				"04048944598",
				"olanormann@noreg.no"
			));
		_context.SaveChanges();
		
		personService.AddNewAccount(save.InitializeAccount("sparekonto", 1, "89934989892134"));
		_context.SaveChanges();
		Assert.That(accountService.GetById(1).OwnerId, Is.EqualTo(personService.GetById(accountService.GetById(1).OwnerId).Id));
	}
}