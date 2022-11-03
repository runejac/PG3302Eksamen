using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PG3302Eksamen.Repositories;

public class BankContextWrapper : IDisposable {
    private DbConnection _connection;

    public BankContextWrapper(DbConnection connection) {
        _connection = connection;
    }

    public void Dispose() {
        _connection.Dispose();
        _connection = null;
    }

    public DbContextOptions<BankContext> CreateOptions() {
        return new DbContextOptionsBuilder<BankContext>()
            .UseSqlite(_connection).Options;
    }

    public BankContext CreateContext() {
        return new BankContext(CreateOptions());
    }
}