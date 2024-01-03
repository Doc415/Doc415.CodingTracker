using Microsoft.Extensions.Configuration;
using System.Configuration;
namespace Doc415.CodingTracker;

internal class Program
{
        static void Main(string[] args)
    {
        var DataAccess = new DataAccess();

        DataAccess.CreateDatabase();

        UserInterface.MainMenu();
    }
}
