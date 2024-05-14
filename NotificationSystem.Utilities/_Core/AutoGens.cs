using System.Text;

namespace NotificationSystem.Utilities;

public class AutoGens
{
    private static int upper = 99999999;
    private static int lower = 12345678;

    public static string GenerateBatchNumber()
    {
        var random = new Random();
        var batchNumber = random.Next(lower, upper);
        if (batchNumber == 0)
        {
            batchNumber = random.Next(lower, upper);
            if (batchNumber == 0)
            {
                throw new ApplicationException("Unable to generate batch Number");
            }
        }
        
        return batchNumber.ToString("D8");
    }
    public static string GeneratePinNumber()
    {
        var random = new Random();
        StringBuilder builder = new();
        for (int i = 0; i <= 11; i++)
        {
            builder.Append(random.Next(1, 10));
        }
        if(builder == null)
        {
            builder = new StringBuilder();
            for (int i = 0; i <= 11; i++)
            {
                builder.Append(random.Next(1, 10));
            }
            if(builder == null)
            {
                throw new ArgumentException("Unable to generate Pin Number");
            }
        }
        return builder.ToString();

    }
    public static string GenerateSerialNumber()
    {
        var random = new Random();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i <= 14; i++)
        {
            builder.Append(random.Next(1, 10));
        }
        if (builder == null)
        {
            builder = new StringBuilder();
            for (int i = 0; i <= 11; i++)
            {
                builder.Append(random.Next(1, 10));
            }
            if (builder == null)
            {
                throw new ArgumentException("Unable to generate Serial Number");
            }
        }
        return builder.ToString();
    }
}
