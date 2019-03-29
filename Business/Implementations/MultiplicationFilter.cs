using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class MultiplicationFilter : OperationFilter
    {
        #region Public methods

        public MultiplicationFilter(IOperandFounder operandFounder) : base(operandFounder, "*") { }

        #endregion

        #region Protected methods

        protected override double GetOperationResult(double firstOperand, double secondOperand)
        {
            double result = firstOperand * secondOperand;

            return result;
        }

        #endregion
    }
}
