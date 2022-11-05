using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

//get all account numbers, change account name, update account balance
public class AccountHandlerTest {
    private BankContext _context = new();
    private bool disposedValue; // To detect redundant calls


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
    public void ChangeAccountNameTest() {
        AccountRepository accountRepository = new(_context);
        
        var currentAccount = new CurrentAccountFactory().InitializeAccount("Felleskonto", 1, "12345678912");
        
        accountRepository.Insert(currentAccount);
        accountRepository.ChangeAccountName(1, "Brukerkonto");
        var expectedAccountNumber = accountRepository.GetById(1).Name;
        
        Assert.That(expectedAccountNumber, Is.EqualTo("Brukerkonto"));
    }
    /*
    [Test]

    public void CreateAccountTest() {
        var currentAccount = new CurrentAccountFactory().InitializeAccount("Felleskonto", 1, "12345678912");
        
        _context.SaveChanges();
        Assert.That(currentAccount.Owne);
    }*/
}