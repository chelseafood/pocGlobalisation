using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace ConsoleApp_GlobalisationDateTime
{
    class Program
    {
        public static void Main()
        {
            // Persist two dates as strings.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            DateTime[] dates = { new DateTime(2013, 1, 9),
                           new DateTime(2013, 8, 18) };
            StreamWriter sw = new StreamWriter("dateData.dat");
            sw.Write(String.Format(CultureInfo.InvariantCulture,
                                   "{0:d}|{1:d}", dates[0], dates[1]));
            sw.Close();

            // Read the persisted data.
            StreamReader sr = new StreamReader("dateData.dat");
            string dateData = sr.ReadToEnd();
            sr.Close();
            string[] dateStrings = dateData.Split('|');

            // Restore and display the data using the conventions of the en-US culture.
            Console.WriteLine("Current Culture: {0}",
                              Thread.CurrentThread.CurrentCulture.DisplayName);
            
            foreach (var dateStr in dateStrings)
            {
                DateTime restoredDate;
                if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out restoredDate))
                    Console.WriteLine("The date is {0:D}", restoredDate);
                else
                    Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
            }
            Console.WriteLine();

            // Restore and display the data using the conventions of the en-GB culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            Console.WriteLine("Current Culture: {0}",
                              Thread.CurrentThread.CurrentCulture.DisplayName);
            foreach (var dateStr in dateStrings)
            {
                DateTime restoredDate;
                if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out restoredDate))
                    Console.WriteLine("The date is {0:D}", restoredDate);
                else
                    Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
            }
            Console.ReadLine();
        }
        //static DateTime[] dates = { new DateTime(2012, 10, 11, 7, 06, 0),
        //                new DateTime(2012, 10, 11, 18, 19, 0) };

        //public static void Main()
        //{
        //    Console.WriteLine("I'm being globalized");
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ta-IN");
        //    ShowDayInfo();
        //    Console.WriteLine();
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        //    ShowDayInfo();
        //    Console.ReadLine();
        //}

        //private static void ShowDayInfo()
        //{
        //    Console.WriteLine("Date: {0:D}", dates[0]);
        //    Console.WriteLine("   Sunrise: {0:T}", dates[0]);
        //    Console.WriteLine("   Sunset:  {0:T}", dates[1]);
        //}
    }
}
