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
        

        static void Main(string[] args)
        {
            Console.WriteLine(validateSeries(args.ToString()));
        }
    }
}
