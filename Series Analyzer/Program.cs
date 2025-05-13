using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer
{
    internal class Program
    {
        //משתנה גלובלי של סדרת המספרים.
        static List<float> currentSeries = new List<float>();

        //הדפסת שגיאה.
        static void printError()
        {
            Console.WriteLine("Invalid input please try agin: ");
        }
        
        //בדיקה האם הסדרה עומדת בדרישות קלט.
        static bool validateSeries(string[] series)
        {
            if (series.Length < 3)
            {
                return false;
            }
            foreach (string item in series)
            {
                if ((item != " ") && (! float.TryParse(item, out _)))
                {
                    return false;
                }

                if (float.Parse(item) <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        //קבלת סדרת מספרים מהמשתמש ובדיקת הקלט.
        static string[] getSeries()
        {
            string[] numStrArr;

            do
            {
                Console.WriteLine("Enter series of positive number with a space: ");
                numStrArr = Console.ReadLine().Split(' ');

                if (! validateSeries(numStrArr))
                {
                    printError();
                }
            }
            while (!validateSeries(numStrArr));

            return numStrArr;
        }

        //המרת סדרת המספרים לרשימה של מספרים.
        static List<float> convertToNum(string[] strNumList)
        {
            List<float> seriesNumbers = new List<float>();

            foreach (string strNum in strNumList)
            {
                if (float.TryParse(strNum, out _))
                {
                    seriesNumbers.Add(float.Parse(strNum));
                }
            }

            return seriesNumbers;
        }

        //הדפסת התפריט וקבלת בחירת המשתמש.
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

            string choice  = Console.ReadLine();

            return choice;
        }

        //אימות בחירת המשתמש.
        static bool validateCoice(string userChoice)
        {
            string[] options = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

            if (! options.Contains(userChoice))
            {
                printError();
                return false;
            }
            return true;
        }

        //לולאה לבקשת בחירה חוזרת כשהקלט לא תקין.
        static string getCoice(string userChoice)
        {
            while (! validateCoice(userChoice))
            {
                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        //הצגת הסדרה בסדר שהמשתמש הכניס.
        static void displayByOrder(List<float> sreies)
        {
            foreach (float num in sreies)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("");
        }

        //בדיקת אורך הסדרה.
        static int seriesLen(List<float> sreies)
        {
            int len = 0;

            foreach (float num in sreies)
            {
                len++;
            }
            return len;
        }

        //הצגת הסדרה בסדר הפוך מהסדר שהמשתמש הכניס.
        static void displayRevers(List<float> sreies)
        {
            int len = seriesLen(sreies);

            for (int i = len - 1; i >= 0; i--)
            {
                Console.Write(sreies[i] + " ");
            }
            Console.WriteLine("");
        }

        //מיון סדרת המספרים.
        static List<float> sortSeries(List<float> sreies)
        {
            int i, j, len;
            float current;
            bool flag;
            len = seriesLen(sreies);

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


        //מציאת המספר הכי גדול בסדרה.
        static float displayMax(List<float> sreies)
        {
            float currentMax = sreies[0];

            foreach (float num in sreies)
            {
                if (num > currentMax)
                {
                    currentMax = num;
                }
            }

           return currentMax;
        }

        //מציאת המספר הכי קטו בסדרה.
        static float displayMin(List<float> sreies)
        {
            float currentMin = sreies[0];

            foreach (float num in sreies)
            {
                if (num < currentMin)
                {
                    currentMin = num;
                }
            }

            return currentMin;
        }

        //חישוב סכום הסדרה.
        static float displaySum(List<float> sreies)
        {
            float sum = 0;

            foreach (float num in sreies)
            {
                sum += num;
            }

            return sum;
        }

        //חישוב ממוצע הסדרה.
        static float displayAverage(List<float> sreies)
        {
            float sum = displaySum(sreies);
            float len = seriesLen(sreies);
            
            return sum / len;
        }

        //ביצוע הפעולה שנבחרה מהתפריט.
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
                        Console.WriteLine(seriesLen(currentSeries));
                        continue;
                    case "i":
                        Console.WriteLine(displaySum(currentSeries));
                        continue;
                }

            }
            while (choice != "j");

            Console.WriteLine("Bey");
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
 
  
