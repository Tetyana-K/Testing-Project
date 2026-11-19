namespace User;
public class UserValidator
{
    public bool IsValidAge(int age)
    {
        return age >= 18;
    }

    public bool IsValidEmail(string email)
    {
        return !string.IsNullOrEmpty(email)
            && email.Contains("@")
            && email.Contains(".");
    }

    public bool IsValidPassword(string password)
    {
        return !string.IsNullOrEmpty(password)
            && password.Length >= 8;
    }
}
