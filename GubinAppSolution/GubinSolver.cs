using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GubinAppSolution
{
    class GubinSolver
    {
        DataSet dataSet;
        public GubinSolver(double[,] array)
        {
            dataSet = DataSet.GetInstance(array);
        }
        public double GetCorrelationScore()
        {
            return dataSet.GetCorrelationScore();
        }
        public bool TestHypothesis(double n)
        {
            return dataSet.TestHypothesis(n);
        }
        public double GetAverageByRow(int index)
        {
            return dataSet.GetAverage(index);
        }
        public double GetDispersionByRow(int index)
        {
            return dataSet.GetDispersion(index);
        }
        public double GetTotalAverage()
        {
            return dataSet.GetTotalAverage();
        }
        public double GetQ1()
        {
            return dataSet.GetQ1();
        }
        public double GetQ2()
        {
            return dataSet.GetQ2();
        }
        public double GetSQ1()
        {
            return dataSet.GetSQ1();
        }
        public double GetSQ2()
        {
            return dataSet.GetSQ2();
        }
        public bool TestMathWaitingHypothesis(double n)
        {
            return dataSet.TestMathWaitingHypothesis(n);
        }

    }
}
