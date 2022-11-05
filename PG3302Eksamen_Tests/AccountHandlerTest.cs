using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;


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

    [Test]
    public void UpdateAccountBalance() {
        AccountRepository accountRepository = new(_context);

        var savingsAccount = new SavingsAccountFactory().InitializeAccount("Sparekonto", 1, "12345678912");
        
        accountRepository.Insert(savingsAccount);
        
        accountRepository.UpdateBalance(accountRepository.GetById(1).Id,2000);
        
        Assert.That(savingsAccount.Balance, Is.EqualTo(2000));
    }

    [Test]

    public void GetAllAccountNumbers() {
        AccountRepository accountRepository = new(_context);
        
        var savingsAccount = new SavingsAccountFactory().InitializeAccount("Sparekonto", 2, "12345678912");

        var currentAccount = new CurrentAccountFactory().InitializeAccount("Brukskonto", 2, "12345678901");
        
        accountRepository.Insert(currentAccount);
        accountRepository.Insert(savingsAccount);
        
        List<string> actual = new List<string>();    
                                              
        actual.Add("12345678901");                   
        actual.Add("12345678912");  

        Assert.That(accountRepository.GetAllAccountNumbers(), Is.EqualTo(actual));

    }

    //Assert.That(accountRepository.GetAllAccountNumbers(), Has.Count.EqualTo(2));
            
    //(accountRepository.GetAllAccountNumbers().Get);
    
    /*Assert.Multiple((() =>
        {
            Assert.That(savingsAccount.AccountNumber, Is.EqualTo("123456789121"));
            Assert.That(currentAccount.AccountNumber, Is.EqualTo("123456789011"));
        }));*/
    /*
    [Test]

    public void CreateAccountTest() {
        var currentAccount = new CurrentAccountFactory().InitializeAccount("Felleskonto", 1, "12345678912");
        
        _context.SaveChanges();
        Assert.That(currentAccount.Owne);
    }*/
}