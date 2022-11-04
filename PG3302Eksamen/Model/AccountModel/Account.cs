using System.ComponentModel.DataAnnotations.Schema;
using PG3302Eksamen.Interfaces;

namespace PG3302Eksamen.Model.AccountModel;

public abstract class Account : IAccount {
	public int Id { get; set; }

	[NotMapped] public virtual int Interest { get; set; }

	[NotMapped] public virtual int WithdrawLimit { get; set; }

	public string AccountNumber { get; set; }

	public string Name { get; set; }

	public decimal Balance { get; set; } = 1000;

	public int OwnerId { get; set; }

	public DateTime DateOfCreation { get; set; } = DateTime.Now;


	/*public string AccountNumber { get; set; }
	public decimal Balance { get; set; }
	public string Name { get; set; }
	public string Owner { get; set; }

	public DateTime DateOfCreation { get; set; } = DateTime.Now;

	public int WithdrawLimit { get; set; }
	public int Interest { get; set; }
	public virtual AccountTypeEnum Type { get; set; }*/


	/*public bool CloseAccount() {
	    throw new NotImplementedException();
	}*/

	public bool CloseAccount() {
		throw new NotImplementedException();
	}

	public string GetAccountType() {
		return this is SavingAccount ? "savings account" : "current account";
	}
}