using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Model;

public class Transaction {
    public int Id { get; set; }
    public int Receipt { get; set; }
    public DateTime Date { get; set; }
    public string FromAccount { get; set; }
    public string ToAccount { get; set; }
    
    public Transaction CreateTransaction(int receipt, DateTime date, string fromAccount, string toAccount) {
        return new Transaction {
            Receipt = receipt,
            Date = date,
            FromAccount = fromAccount,
            ToAccount = toAccount
        };
    }
}