namespace PG3302Eksamen.Interfaces;

public interface IUnitOfWork : IDisposable {
    IAccountRepository Account { get; }
    IBillRepository Bills { get; }
    IPersonRepository Person { get; }
    ITransactionRepository Transaction { get; }

    int Complete();
}