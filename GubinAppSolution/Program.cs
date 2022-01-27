using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GubinAppSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] x =
            {
                {14.9,13.4,13.3,13},
                { 14.2,14,15.3,14.7},
                { 14.6,13.7,17.5,16.3},
                {18.3,17.8,16.8,18.6 },
                {19.1,18.7,16.2,16.5 }
            };

            GubinSolver gubinSolver = new GubinSolver(x);
               for (int i = 0; i < x.GetLength(0); i++){ Console.WriteLine($"The average of {i + 1} row: {gubinSolver.GetAverageByRow(i)}"); }
               Console.WriteLine($"The total average: {gubinSolver.GetTotalAverage()}");
               Console.WriteLine($"Q1: {gubinSolver.GetQ1()}");
               Console.WriteLine($"Q2: {gubinSolver.GetQ2()}");
               Console.WriteLine($"SQ1: {gubinSolver.GetSQ1()}");
               Console.WriteLine($"SQ2: {gubinSolver.GetSQ2()}");
               Console.WriteLine($"Accepting hypothesis: {gubinSolver.TestMathWaitingHypothesis(3.24)}");
        }
    }
}
