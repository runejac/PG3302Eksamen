using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Model;

public class Transaction {
    public int Id { get; set; }
    public int Receipt { get; set; }
    public DateTime Date { get; set; }
    public Account FromAccount { get; set; }
    public string ToAccount { get; set; }
}