using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Business.Implementations
{
    public class SubtractionFilter : OperationFilter
    {
        #region Public methods

        public SubtractionFilter(IOperandFounder operandFounder) : base(operandFounder, "-") { }

        #endregion

        #region Protected methods

        protected override int GetFirstOperationIndex(string expression)
        {
            int index = _notFoundIndex;

            //Special search by regex because minus symbol can represent an operation or a negative number
            Regex regexp = new Regex(@"[0123456789]{1}[-]{1}[-0123456789]{1}");
            MatchCollection matchCollection = regexp.Matches(expression);

            if (matchCollection.Count > 0)
            {
                Match match = matchCollection[0];

                index = match.Index + 1;
            }

            return index;
        }

        protected override double GetOperationResult(double firstOperand, double secondOperand)
        {
            double result = firstOperand - secondOperand;

            return result;
        }

        #endregion
    }
}
