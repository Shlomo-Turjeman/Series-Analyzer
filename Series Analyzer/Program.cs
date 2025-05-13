using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer
{
    internal class Program
    {
        static List<int> currentSeries = new List<int>();

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
                "b. Display the series in the order it was entered.\n" +
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

            Console.WriteLine("");
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

            for (int i = len -1; i >= 0; i--)
            {
                Console.Write(sreies[i] + ",");
            }
            Console.WriteLine("");
        }

        static List<int> sortSeries(List<int> sreies)
        {
            int i, j, len, current;
            bool flag;
            len = sreies.Count;

            for (i = 0; i < len - 1; i++)
            {
                flag = false;
                for (j = 0; j < len - i - 1; j++)
                {
                    if (sreies[j] > sreies[j + 1])
                    {
                        current = sreies[j];
                        sreies[j] = sreies[j + 1];
                        sreies[j + 1] = current;
                        flag = true;
                    }
                }

                if (! flag)
                    break;
            }
            return sreies;
        }

        static int displayMax(List<int> sreies)
        {
            int currentMax = sreies[0];

            foreach (int num in sreies)
            {
                if (num > currentMax)
                {
                    currentMax = num;
                }
            }

           return currentMax;
        }

        static int displayMin(List<int> sreies)
        {
            int currentMin = sreies[0];

            foreach (int num in sreies)
            {
                if (num < currentMin)
                {
                    currentMin = num;
                }
            }

            return currentMin;
        }

        static int displaySum(List<int> sreies)
        {
            int sum = 0;

            foreach (int num in sreies)
            {
                sum += num;
            }

            return sum;
        }

        static int displayLenght(List<int> sreies)
        {
            int len = 0;

            foreach (int num in sreies)
            {
                len++;
            }

            return len;
        }

        static int displayAverage(List<int> sreies)
        {
            int sum = displaySum(sreies);
            int len = displayLenght(sreies);
            
            return sum / len;
        }

        static void runMenu()
        {
            string choice;

            do
            {
                choice = getCoice(menu());

                switch (choice)
                {
                    case "a":
                        currentSeries = convertToNum(getSeries());
                        continue;
                    case "b":
                        displayByOrder(currentSeries);
                        continue;
                    case "c":
                        displayRevers(currentSeries);
                        continue;
                    case "d":
                        displayByOrder(sortSeries(currentSeries));
                        continue;
                    case "e":
                        Console.WriteLine(displayMax(currentSeries));
                        continue;
                    case "f":
                        Console.WriteLine(displayMin(currentSeries));
                        continue;
                    case "g":
                        Console.WriteLine(displayAverage(currentSeries));
                        continue;
                    case "h":
                        Console.WriteLine(displayLenght(currentSeries));
                        continue;
                    case "i":
                        Console.WriteLine(displaySum(currentSeries));
                        continue;
                }

            }
            while (choice != "j");
        }



        static void Main(string[] args)
        {

            if (validateSeries(args))
            {
                currentSeries = convertToNum(args);
            }
           else
            {
                currentSeries = convertToNum(getSeries());
            }

            runMenu();
        }
    }
}
 
  