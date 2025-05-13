using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer
{
    internal class Program
    {

        static bool validateSeries(string[] series)
        {
            Console.WriteLine(series);
            if (series.Length < 3)
            {
                return false;
            }
            foreach (string item in series)
            {
                if ((item != " ") && (! int.TryParse(item, out _)) && (int.Parse(item) < 0))
                {
                    Console.WriteLine(item);
                    return false;
                }
            }

            return true;
        }
        static string[] getSeries()
        {
            string strNumbers = "";
            string[] numStrArr;

            do
            {
                Console.WriteLine("Enter series of number with a space: ");
                strNumbers = Console.ReadLine();
                numStrArr = strNumbers.Split(' ');

            }
            while (!validateSeries(numStrArr));

            return numStrArr;
        }

        static List<int> convertToNum(string[] strNumList)
        {
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
            List<int> newSeries = convertToNum(getSeries());

            foreach (int num in sreies)
            {
                sreies.Add(num);
            }
            return sreies;
        }

        static void displayByOrder(List<int> sreies)
        {
            foreach (int num in sreies)
            {
                Console.Write(num + ",");
            }
        }

        static int seriesLen(List<int> sreies)
        {
            int len = 0;
            
            foreach (int num in sreies)
            {
                len++;
            }
            return len;
        }
           
        static void displayRevers(List<int> sreies)
        {
            int len = seriesLen(sreies);

            for (int i = len; i >= 0; i--)
            {
                Console.Write(i + ",");
            }
        }
        static void Main(string[] args)
        {
            List<int> currentSeries = new List<int>();
            string choice;
            Console.WriteLine(validateSeries(args)); 

            if (validateSeries(args))
            {
                currentSeries = convertToNum(args);
            }
           else
            {
                currentSeries = convertToNum(getSeries());
            }

            foreach (int num in currentSeries)
            {
                Console.Write(num + ",");
            }
            
            do
            {
                choice = getCoice(menu());
            }
            while (choice != "j");

        }
    }
}
