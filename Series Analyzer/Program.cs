using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer
{
    internal class Program
    {

        static bool validateSeries(string series)
        {
            if (series.Replace(" ", "").Length < 3)
            {
                return false;
            }
            foreach (char item in series)
            {
                if ((item.ToString() != " ") && (item < '0' || item > '9'))
                {
                    return false;
                }
            }

            return true;
        }
        static string[] getSeries()
        {
            string strNumbers = "";
            do
            {
                Console.WriteLine("Enter series of number with a space");
                strNumbers = Console.ReadLine();
            }
            while (!validateSeries(strNumbers));

            string[] numStrArr = strNumbers.Split(' ');

            return numStrArr;
        }

        static List<int> convertToNum()
        {
            string[] strNumList = getSeries();

            List<int> seriesNumbers = new List<int>();

            foreach (string strNum in strNumList)
            {
                if (int.TryParse(strNum, out _))
                {
                    seriesNumbers.Add(int.Parse(strNum));
                }
            }

            return seriesNumbers;
        }


        static string menu()
        {
            Console.WriteLine("Menu:\n" +
                "a. Input a Series. (Replace the current series)\n" +
                "b. Display the series in the order it was entered." +
                "c. Display the series in the reversed order it was entered.\n" +
                "d. Display the series in sorted order (from low to high).\n" +
                "e. Display the Max value of the series.\n" +
                "f. Display the Min value of the series.\n" +
                "g. Display the Average of the series.\n" +
                "h. Display the Number of elements in the series.\n" +
                "i. Display the Sum of the series.\n" +
                "j. Exit.\n" + 
                "Enter your choice: ");

            string coich  = Console.ReadLine();

            return coich;
        }

        static bool validateCoice(string userChoice)
        {
            string[] options = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

            return options.Contains(userChoice);
        }

        static string getCoice(string userChoice)
        {
            while (! validateCoice(userChoice))
            {
                Console.WriteLine("Invalid choice please try agin: ");
                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        static List<int> replaceSreies(List<int> sreies)
        {
            sreies.Clear();
            List<int> newSeries = convertToNum();

            foreach (int num in sreies)
            {
                sreies.Add(num);
            }
            return sreies;
        }


        static void Main(string[] args)
        {
            List<int> currentSeries = new List<int>();
            string choice;

            if (! validateSeries(args.ToString()))
            {
                currentSeries = convertToNum();
            }
           else
            {
                currentSeries = convertToNum();
            }

            do
            {
                choice = getCoice(menu());
            }
            while (choice != "j");

        }
    }
}
