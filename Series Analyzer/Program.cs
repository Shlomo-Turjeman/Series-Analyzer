using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Analyzer
{
    internal class Program
    {
        //משתנה גלובלי של סדרת המספרים
        static List<float> currentSeries = new List<float>();

        //הדפסת שגיאה.
        static void printError()
        {
            Console.WriteLine("Invalid input please try again: ");
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
        static string displayMenu()
        {
            Console.WriteLine("********Menu********\n" +
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

            string choich  = Console.ReadLine();

            return choich;
        }

        //אימות בחירת המשתמש.
        static bool validateChoice(string userChoice)
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
        static string getChoice(string userChoice)
        {
            while (! validateChoice(userChoice))
            {
                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        //הצגת הסדרה בסדר שהמשתמש הכניס.
        static void displayByOrder(List<float> series)
        {
            foreach (float num in series)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("");
        }

        //בדיקת אורך הסדרה.
        static int seriesLen(List<float> series)
        {
            int len = 0;

            foreach (float num in series)
            {
                len++;
            }
            return len;
        }

        //הצגת הסדרה בסדר הפוך מהסדר שהמשתמש הכניס.
        static void displayReverse(List<float> series)
        {
            int len = seriesLen(series);

            for (int i = len - 1; i >= 0; i--)
            {
                Console.Write(series[i] + " ");
            }
            Console.WriteLine("");
        }

        //מיון סדרת המספרים.
        static List<float> sortSeries(List<float> series)
        {
            int i, j, len;
            float current;
            bool flag;
            len = seriesLen(series);

            for (i = 0; i < len - 1; i++)
            {
                flag = false;
                for (j = 0; j < len - i - 1; j++)
                {
                    if (series[j] > series[j + 1])
                    {
                        current = series[j];
                        series[j] = series[j + 1];
                        series[j + 1] = current;
                        flag = true;
                    }
                }

                if (! flag)
                    break;
            }
            return series;
        }


        //מציאת המספר הכי גדול בסדרה.
        static float displayMax(List<float> series)
        {
            float currentMax = series[0];

            foreach (float num in series)
            {
                if (num > currentMax)
                {
                    currentMax = num;
                }
            }

           return currentMax;
        }

        //מציאת המספר הכי קטו בסדרה.
        static float displayMin(List<float> series)
        {
            float currentMin = series[0];

            foreach (float num in series)
            {
                if (num < currentMin)
                {
                    currentMin = num;
                }
            }

            return currentMin;
        }

        //חישוב סכום הסדרה.
        static float displaySum(List<float> series)
        {
            float sum = 0;

            foreach (float num in series)
            {
                sum += num;
            }

            return sum;
        }

        //חישוב ממוצע הסדרה.
        static float displayAverage(List<float> series)
        {
            float sum = displaySum(series);
            float len = seriesLen(series);
            
            return sum / len;
        }

        //ביצוע הפעולה שנבחרה מהתפריט.
        static void runMenu()
        {
            string choice, validateChoice;

            do
            {

                choice = displayMenu();
                validateChoice = getChoice(choice);

                switch (choice)
                {
                    case "a":
                        string[] stringSeries = getSeries();
                        currentSeries = convertToNum(stringSeries);
                        continue;
                    case "b":
                        displayByOrder(currentSeries);
                        continue;
                    case "c":
                        displayReverse(currentSeries);
                        continue;
                    case "d":
                        List<float> sortNumSeries = sortSeries(currentSeries);
                        displayByOrder(sortNumSeries);
                        continue;
                    case "e":
                        float max = displayMax(currentSeries);
                        Console.WriteLine(max);
                        continue;
                    case "f":
                        float min = displayMin(currentSeries);
                        Console.WriteLine(min);
                        continue;
                    case "g":
                        float average = displayAverage(currentSeries);
                        Console.WriteLine(average);
                        continue;
                    case "h":
                        int len = seriesLen(currentSeries);
                        Console.WriteLine(len);
                        continue;
                    case "i":
                        float sum = displaySum(currentSeries);
                        Console.WriteLine(sum);
                        continue;
                }

            }
            while (choice != "j");

            Console.WriteLine("Closing...");
        }

        static void Main(string[] args)
        {
            bool isValidate = validateSeries(args);

            if (isValidate)
            {
                currentSeries = convertToNum(args);
            }
           else
            {
                string[] stringSeries = getSeries();
                currentSeries = convertToNum(stringSeries);
            }

            runMenu();
        }
    }
}
