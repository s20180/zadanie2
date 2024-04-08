using System;

namespace LegacyApp;

public class UserValidationService
{
    public bool validateUserData(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        return validateUserName(firstName, lastName) && validateUserEmail(email) && validateAge(dateOfBirth);
    }

    private bool validateUserName(string firstName, string lastName)
    {
        return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
    }

    private bool validateUserEmail(string email)
    {
        return !(!email.Contains("@") && !email.Contains("."));
    }

    private bool validateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age > 21;
    }

    public bool validateUserCredit(User user)
    {
        return user.HasCreditLimit && user.CreditLimit < 500;
    }
}