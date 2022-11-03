using System.Text.RegularExpressions;

namespace PG3302Eksamen.Utils;

public static class TrimUtil {
	public static string TrimInput(string input) {
		var regex = new Regex("[ ]{2,}", RegexOptions.None);
		input = regex.Replace(input, " ");
		return input;
	}
}