using Microsoft.Extensions.Configuration;
using System.Configuration;
namespace Doc415.CodingTracker;

internal class Program
{
    static public string connectionString;
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];

        var DataAccess = new DataAccess(connectionString);

        DataAccess.CreateDatabase();

        UserInterface.MainMenu();
    }
}
