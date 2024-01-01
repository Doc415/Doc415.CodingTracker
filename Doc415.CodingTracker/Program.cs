using System;
using System.Configuration;
using System.Collections.Specialized;
namespace Doc415.CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string sAttr = ConfigurationManager.AppSettings.Get("Key0");

            Console.WriteLine(sAttr);
        }
    }
}
