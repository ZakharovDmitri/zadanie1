using System;
using System.Globalization;
using System.IO;

namespace zadanie1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] input;
            string[][] inputForSolve;
            string output;

            using (StreamReader sw = new StreamReader("INPUT.TXT"))
            {
                input = sw.ReadToEnd().Split('\n');
                inputForSolve = new string[input.Length][];
                for (int i = 0; i < input.Length; i++)
                {
                    string[] splitInput = input[i].Split(' ');
                    inputForSolve[i] = new string[splitInput.Length];
                    for (int j = 0; j < splitInput.Length; j++)
                    {
                        inputForSolve[i][j] = splitInput[j];
                    }
                }
            }

            output = Solve(inputForSolve);

            using (StreamWriter sw = new StreamWriter("OUTPUT.TXT"))
            {
                sw.Write(output);
            }
        }

        public static double AsDouble(string s)
        {
            try
            {
                return double.Parse(s, CultureInfo.GetCultureInfo("uk"));
            }
            catch (FormatException)
            {
                return double.Parse(s, CultureInfo.InvariantCulture);
            }
        }

        private static string Solve(string[][] input)
        {
            bool isCompressed = true;
            double n = AsDouble(input[0][0]);
            double q = AsDouble(input[0][1]);

            for (int i = 1; i <= n; ++i)
            {
                double x1 = AsDouble(input[i][0]);
                double x2 = AsDouble(input[i][1]);
                double y1 = AsDouble(input[i][2]);
                double y2 = AsDouble(input[i][3]);
                double dx = Math.Sqrt(x1 * x1 + x2 * x2) * 1000;
                double dy = Math.Sqrt(y1 * y1 + y2 * y2) * 1000;

                if (dx * q < dy)
                {
                    isCompressed = false;
                }
            }

            return isCompressed ? "Yes" : "No";
        }
    }
}

