using System.ComponentModel.DataAnnotations.Schema;

namespace A_Team.Core.Model.AccountModel;

public class CurrentAccount : Account {
	// TODO sjekke om vi skal bruke const her eller ikke, senere
	[Column("Interest")] public override int Interest { get; set; } = 2;

	// TODO sjekke om vi skal bruke const her eller ikke, senere
	[Column("WithdrawLimit")] public override int WithdrawLimit { get; set; } = 0;
}