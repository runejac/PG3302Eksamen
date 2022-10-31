using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Transaction {
    public int Id { get; set; }
    public int Receipt { get; set; }
    public DateTime Date { get; set; }
    public Account FromAccount { get; set; }
    public string ToAccount { get; set; }
}