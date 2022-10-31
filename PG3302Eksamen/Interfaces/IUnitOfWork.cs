using PG3302Eksamen.Interfaces;

namespace A_Team.Core.Interfaces;

public interface IUnitOfWork : IDisposable {
    IAccountRepository Account { get; }
    IBillRepository Bills { get; }
    IPersonRepository Person { get; }
    ITransactionRepository Transaction { get; }

    int Complete();
}