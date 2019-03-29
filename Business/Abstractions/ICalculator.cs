using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface ICalculator
    {
        /// <summary>Evaluates the expression and gets the result
        /// </summary>
        double Evaluate(String expression);
    }
}
