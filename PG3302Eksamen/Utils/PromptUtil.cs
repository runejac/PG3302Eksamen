using Spectre.Console;

namespace PG3302Eksamen.Utils;

public class PromptUtil {
    private static string msg;

    public static void setMessage(string message) {
        msg = message;
    }

    public static string getMessage() {
        return msg;
    }

    public static bool PromptQuestion(string text) {
        return AnsiConsole.Confirm("[green]" + text + "[/]");
    }

    public static string PromptSelectPrompt(string? title, string[] questions) {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .AddChoices(questions));
    }
}