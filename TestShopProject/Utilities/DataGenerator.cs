using TestShopProject.Models;

namespace TestShopProject.Utilities;

public class DataGenerator
{
    private static readonly Random _random = new Random();

    public static UserData GenerateUser()
    {
        int randomNumber = _random.Next(1000, 9999);

        return new UserData
        {
            FirstName = $"TestName{randomNumber}",
            LastName = $"TestLastName{randomNumber}",
            Email = $"testemail{randomNumber}@gmail.com",
            Password = GenerateRandomPassword(6)
        };
    }

    private static string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}