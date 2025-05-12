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

        static void Main(string[] args)
        {
            Console.WriteLine(validateSeries(args.ToString()));
        }
    }
}
