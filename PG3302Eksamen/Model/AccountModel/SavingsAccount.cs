// Concrete Products provide various implementations of the Product
// interface.

using System.ComponentModel.DataAnnotations.Schema;

namespace A_Team.Core.Model.AccountModel;

public class SavingAccount : Account {
	[Column("Interest")] public override int Interest { get; set; } = 15;

	[Column("WithdrawLimit")] public override int WithdrawLimit { get; set; } = 20;
}