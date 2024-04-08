namespace LegacyApp;

public abstract class ClientType
{
    public virtual void evalUserCredit(User user)
    {
        user.HasCreditLimit = true;
        setCreditLimit(user);
    }

    protected void setCreditLimit(User user, int multiplier = 1)
    {
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit *= multiplier;
            user.CreditLimit = creditLimit;
        }
    }
}

public class NormalClient : ClientType {}

public class ImportantClient : ClientType
{
    public override void evalUserCredit(User user)
    {
        setCreditLimit(user, 2);
    }
}

public class VeryImportantClient : ClientType
{
    public override void evalUserCredit(User user)
    {
        user.HasCreditLimit = false;
    }
}