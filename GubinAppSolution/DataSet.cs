using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GubinAppSolution
{
    class DataSet
    {
        private double[,] array;
        private DataSet(double[,] array) 
        {
            this.array = new double[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    this.array[i, k] = array[i, k];
                }
            }
        }
        private static DataSet instance;
        public static DataSet GetInstance(double[,] array)
        {
            if (instance == null)
            {
                instance = new DataSet(array);
            }
            return instance;
        }
        public double GetAverage(int n)
        {
            double average = default;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                average += array[n, i];
            }
            return average /= array.GetLength(1);
        }
        public double GetDispersion(int n)
        {
            double dispersion = default;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                dispersion += Math.Pow(array[n, i] - GetAverage(n), 2);
            }
            return dispersion /= array.GetLength(1);
        }
        public double GetTotalAverage()
        {
            double result = default;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                result += GetAverage(i);
            }
            return result / array.GetLength(0);
        }
        public double GetQ1()
        {
            double result = default;
            double totalAverage = GetTotalAverage();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                result += Math.Pow(GetAverage(i) - totalAverage, 2);
            }
            return result * array.GetLength(1);
        }
        public double GetQ2()
        {
            double result = default;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result += Math.Pow(array[i, j] - GetAverage(i), 2);
                }
            }
            return result;
        }
        public double GetSQ1()
        {
            return GetQ1() / (array.GetLength(0) - 1);
        }
        public double GetSQ2()
        {
            return GetQ2() / (array.GetLength(0) * array.GetLength(1) - array.GetLength(0));
        }
        public bool TestMathWaitingHypothesis(double n)
        {
            double x = GetSQ1();
            double y = GetSQ2();
            double k = (x > y) ? x : y / ((x < y) ? x : y);
            return k > n ? false : true;
        }
        public double GetCorrelationScore()
        {
            double k = default;
            double result = default;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                k += (array[0, i] - GetAverage(0)) * (array[1, i] - GetAverage(1));
            }
            k /= array.GetLength(1);
            result = k / (Math.Sqrt(GetDispersion(0)) * Math.Sqrt(GetDispersion(1)));
            return result;
        }
        public bool TestHypothesis(double n)
        {
            double k = default;
            double correlationScore = GetCorrelationScore();
            k = (correlationScore * Math.Sqrt(array.GetLength(1) - 2)) / (Math.Sqrt(1 - Math.Pow(correlationScore, 2)));
            return Math.Abs(k) > n;
        }

    }
}
