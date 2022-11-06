namespace PG3302Eksamen.Utils;

public static class AmountGeneratorUtil {
	public static decimal GenerateAmount(int min, int max) {
		// for billing purposes, we want to generate a random amount between min and max
		var random = new Random();
		var amount = random.Next(min, max);
		return amount;
	}
}