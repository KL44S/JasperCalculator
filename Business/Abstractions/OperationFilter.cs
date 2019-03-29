using Business.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Business.Abstractions
{
    public abstract class OperationFilter : ExpressionFilter
    {
        #region Attributes

        protected static int _notFoundIndex = -1;

        protected string _operationSymbol;
        protected IOperandFounder _operandFounder;

        #endregion

        #region Private methods

        //This filters the string replacing a single operation with its result.
        private string FilterSingleExpression(string expression, int index)
        {
            double firstOperand = this._operandFounder.GetFirstOperandFromOperationIndex(expression, index);
            double secondOperand = this._operandFounder.GetSecondOperandFromOperationIndex(expression, index);

            double result = this.GetOperationResult(firstOperand, secondOperand);

            int firstOperandLength = firstOperand.ToString().Length;
            int secondOperandLength = secondOperand.ToString().Length;

            int startIndex = (index - firstOperandLength);
            int lengthToRemove = firstOperandLength + secondOperandLength + this._operationSymbol.Length;

            StringBuilder stringBuilder = new StringBuilder(expression);
            stringBuilder.Remove(startIndex, lengthToRemove);
            stringBuilder.Insert(startIndex, result.ToString(CultureInfo.GetCultureInfo(Constants.DefaultCulture)));

            return stringBuilder.ToString();
        }

        #endregion

        #region Protected methods

        protected abstract double GetOperationResult(double firstOperand, double secondOperand);

        protected OperationFilter(IOperandFounder operandFounder, string operationSymbol)
        {
            this._operandFounder = operandFounder;
            this._operationSymbol = operationSymbol;
        }

        protected virtual int GetFirstOperationIndex(string expression)
        {
            int index = expression.IndexOf(this._operationSymbol);

            return index;
        }

        //This filters every single operation found
        protected override string DoFilterExpression(string expression)
        {
            Boolean operationFound = false;

            do
            {
                int index = this.GetFirstOperationIndex(expression);
                operationFound = (index != _notFoundIndex);

                if (operationFound)
                {
                    expression = this.FilterSingleExpression(expression, index);
                }

            } while (operationFound);

            return expression;
        }

        #endregion
    }
}
