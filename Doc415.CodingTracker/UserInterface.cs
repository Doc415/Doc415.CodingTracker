using System;
using Spectre.Console;
using Doc415.CodingTracker;
using static Doc415.CodingTracker.Enums;
using System.Net.NetworkInformation;
public class UserInterface
{
	public UserInterface()
    {

	}
    public void MainMenu()
    {
        while(true) {

            var selection = AnsiConsole.Prompt(new SelectionPrompt<MainMenuSelections>()
            .Title("Welcome to [green] Coding Tracker [/]\n What would you like to do?")
            .PageSize(10)
            .MoreChoicesText("Use arrow keys for more selection")
            .AddChoices(
               MainMenuSelections.StartNewSession
             , MainMenuSelections.ListTodaysSessions
             , MainMenuSelections.Statistics
             , MainMenuSelections.QuitProgram));

            switch (selection)
            {
                case MainMenuSelections.StartNewSession:
                    StartNewSession();
                    break;
                case MainMenuSelections.ListTodaysSessions:
                    ListTodaysSessions();
                    break;
                case MainMenuSelections.Statistics:
                    Statistics();
                    break;
                case MainMenuSelections.QuitProgram:
                    Environment.Exit(0);
                    break;
            }
        }

        void StartNewSession()
        {

        }

        void ListTodaysSessions()
        {

        }

        void Statistics()
        {

        }
    }
}
