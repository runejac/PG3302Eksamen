using System.Text.RegularExpressions;

namespace PG3302Eksamen.Utils;

public static class TrimUtil {
    /// <summary>
    ///     Trims inputs from user
    /// </summary>
    /// <param name="input"></param>
    /// <returns>
    ///     Returns a clean string with leading and trailing none-whitespaces and also leaves max 1 space in between words
    ///     in a sentence
    /// </returns>
    public static string TrimInput(string input) {
        var regex = new Regex("[ ]{2,}", RegexOptions.None);
        input = regex.Replace(input, " ");
        return input;
    }
}