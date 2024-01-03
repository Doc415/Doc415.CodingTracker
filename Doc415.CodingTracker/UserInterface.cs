using Doc415.CodingTracker;
using Spectre.Console;
using System.Globalization;
using static Doc415.CodingTracker.Enums;
internal static class UserInterface
{
    public static void MainMenu()
    {
        var isMenuRunning = true;
        while (isMenuRunning)
        {
            AnsiConsole.Write(new FigletText("Coding Tracker").LeftJustified().Color(Color.DarkGreen));

            var selection = AnsiConsole.Prompt(new SelectionPrompt<MainMenuSelections>()
             .Title("Welcome to [green] Coding Tracker [/]\nWhat would you like to do?")
             .PageSize(10)
             .MoreChoicesText("Use arrow keys for more selection")
             .AddChoices(
                MainMenuSelections.AddRecord
              , MainMenuSelections.ViewRecords
              , MainMenuSelections.DeleteRecord
              , MainMenuSelections.UpdateRecord,
                MainMenuSelections.Quit)
             );

            switch (selection)
            {
                case MainMenuSelections.AddRecord:
                    AddRecord();
                    break;
                case MainMenuSelections.ViewRecords:
                    ViewRecords();
                    break;
                case MainMenuSelections.DeleteRecord:
                    DeleteRecord();
                    break;
                case MainMenuSelections.UpdateRecord:
                    UpdateRecord();
                    break;
                case MainMenuSelections.Quit:
                    Console.Clear();
                    AnsiConsole.Write(new FigletText("Goodbye").LeftJustified().Color(Color.Yellow));
                    isMenuRunning = false;
                    break;
            }
        }
    }
    private static void AddRecord()
    {
        CodingRecord record = new();

        var dateInputs = GetDateInputs();
        record.DateStart = dateInputs[0];
        record.DateEnd = dateInputs[1];

        var dataAccess = new DataAccess();
        dataAccess.InsertRecord(record);
    }

    private static void ViewRecords()
    {

    }

    private static void DeleteRecord()
    {

    }

    private static void UpdateRecord()
    {

    }

    private static DateTime[] GetDateInputs()
    {
        var startDateInput = AnsiConsole.Ask<string>("Input Start Date with the format: dd-mm-yy hh:mm (24 hour clock). Or enter 0 to return to main menu.");

        if (startDateInput == "0") MainMenu();

        DateTime startDate;
        while (!DateTime.TryParseExact(startDateInput, "dd-MM-yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
        {
            startDateInput = AnsiConsole.Ask<string>("\n\nInvalid date. Format: dd-mm-yy hh:mm (24 hour clock). PLease try again\n\n");
        }

        var endDateInput = AnsiConsole.Ask<string>("Input End Date with the format: dd-mm-yy hh:mm (24 hour clock). Or enter 0 to return to main menu.");

        if (endDateInput == "0") MainMenu();

        DateTime endDate;
        while (!DateTime.TryParseExact(endDateInput, "dd-MM-yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
        {
            endDateInput = AnsiConsole.Ask<string>("\n\nInvalid date. Format: dd-mm-yy hh:mm (24 hour clock). PLease try again\n\n");
        }

        while (startDate > endDate)
        {
            endDateInput = AnsiConsole.Ask<string>("\n\nEnd date can't be before start date. Please try again\n\n");

            while (!DateTime.TryParseExact(endDateInput, "dd-MM-yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                endDateInput = AnsiConsole.Ask<string>("\n\nInvalid date. Format: dd-mm-yy hh:mm (24 hour clock). PLease try again\n\n");
            }
        }

        return [startDate, endDate];
    }
}
