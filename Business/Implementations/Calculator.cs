using Business.Abstractions;
using Business.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Implementations
{
    public class Calculator : ICalculator
    {
        #region Attributes

        private static String _openBracketSymbol = "(";
        private static String _closeBracketSymbol = ")";
        private static int _indexNotFound = -1;

        private IExpressionFilter _expressionFilter;

        #endregion

        #region Private methods

        private string RemoveBrackets(String bracketExpression)
        {
            int noBracketsExpressionStartIndex = 1;
            int noBracketsExpressionLength = bracketExpression.Length - 2;

            String noBracketsExpression = bracketExpression.Substring(noBracketsExpressionStartIndex, noBracketsExpressionLength);

            return noBracketsExpression;
        }

        #endregion

        #region Public methods

        public Calculator(IExpressionFilter expressionFilter)
        {
            this._expressionFilter = expressionFilter;
        }

        public double Evaluate(string expression)
        {
            //Remove all white spaces
            expression = Regex.Replace(expression, @"\s+", String.Empty);

            Boolean bracketExpressionFound = true;

            //I'm finding and solving every expression with brackets
            do
            {
                int firstIndex = expression.LastIndexOf(_openBracketSymbol);

                bracketExpressionFound = (firstIndex != _indexNotFound);

                if (bracketExpressionFound)
                {
                    int lastIndex = expression.IndexOf(_closeBracketSymbol, firstIndex);
                    int subExpressionLength = (lastIndex + 1 - firstIndex);

                    String bracketExpression = expression.Substring(firstIndex, subExpressionLength);
                    String noBracketsExpression = this.RemoveBrackets(bracketExpression);

                    string subExpressionResult = this._expressionFilter.FilterExpression(noBracketsExpression);

                    //Replacing the expression with brackts by its result
                    expression = expression.Replace(bracketExpression, subExpressionResult);
                }
            } while (bracketExpressionFound);

            //Finally, I evaluate the final expression. Which is simple (no brackets)
            string expressionResultAsText = this._expressionFilter.FilterExpression(expression);
            double expressionResult = double.Parse(expressionResultAsText, CultureInfo.GetCultureInfo(Constants.DefaultCulture));

            return expressionResult;
        }

        #endregion
    }
}
