using PG3302Eksamen.Interfaces;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller;

public class TransferController : ITransaction {
    private BankContext _context;
    private readonly AccountRepository _accountRepository;

    private readonly TransactionRepository _transactionRepository;

    private readonly Transfer _transfer = new();

    private Transaction _transaction;

    public TransferController(BankContext context) {
        _context = context;
        _accountRepository = new AccountRepository(_context);
        _transactionRepository = new TransactionRepository(_context);
    }


    public void Pay() {
        throw new NotImplementedException();
    }

    public void Execute() {
        throw new NotImplementedException();
    }

    public Transaction getModel<T>() {
        return _transfer;
    }


    public void Execute(decimal amount, Account fromAccount, Account toAccount) {
        var transaction = _transfer.CreateTransfer(amount, fromAccount, toAccount);

        _transactionRepository.ProcessTransaction(transaction);

        fromAccount.Balance -= amount;
        toAccount.Balance += amount;
        _accountRepository.Update(fromAccount);
        _accountRepository.Update(toAccount);
    }
}