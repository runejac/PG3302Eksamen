namespace PG3302Eksamen.View;

public class UserReader : IUserReader {
    public string? ReadLine() {
        return Console.ReadLine();
    }
}