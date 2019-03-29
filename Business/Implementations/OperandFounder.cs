using Business.Abstractions;
using Business.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Business.Implementations
{
    public class OperandFounder : IOperandFounder
    {
        #region Attributes

        private static char _minusSymbol = '-';
        private static IList<char> _validNumberChars = new List<char>()
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '.'
        };

        #endregion

        #region Private attributes

        private double GetNumber(char[] splittedNumber)
        {
            string numberAsText = new string(splittedNumber);
            double number = double.Parse(numberAsText, CultureInfo.GetCultureInfo(Constants.DefaultCulture));

            return number;
        }

        #endregion

        #region Public attributes

        public double GetFirstOperandFromOperationIndex(string expression, int index)
        {
            Boolean isEndOfNumber = false;
            IList<char> parsedNumber = new List<char>();

            index--;

            //Iterates the string backwards until find something that is not a number.
            while (index >= 0 && !isEndOfNumber)
            {
                char currentChar = expression[index];

                if (_validNumberChars.Contains(currentChar))
                {
                    parsedNumber.Add(currentChar);
                    index--;
                }
                else
                {
                    //When I found something that is not a number I need to check the minus symbol because it can be a negative number
                    if (currentChar.Equals(_minusSymbol))
                    {
                        index--;

                        if (index >= 0)
                        {
                            char nextChar = expression[index];

                            if (!_validNumberChars.Contains(nextChar))
                            {
                                parsedNumber.Add(currentChar);
                            }
                        }
                        else
                        {
                            parsedNumber.Add(currentChar);
                        }
                    }

                    isEndOfNumber = true;
                }
            }

            char[] splittedOperand = parsedNumber.Reverse().ToArray();
            double firstOperand = this.GetNumber(splittedOperand);

            return firstOperand;
        }

        public double GetSecondOperandFromOperationIndex(string expression, int index)
        {
            Boolean isEndOfNumber = false;
            IList<char> parsedNumber = new List<char>();

            index++;
            int startIndex = index;

            //Iterates the string forward until find something that is not a number.
            while (index < expression.Length && !isEndOfNumber)
            {
                char currentChar = expression[index];

                if (_validNumberChars.Contains(currentChar))
                {
                    parsedNumber.Add(currentChar);
                    index++;
                }
                else
                {
                    //It can be the minus symbol of a negative number
                    if (startIndex.Equals(index) && currentChar.Equals(_minusSymbol))
                    {
                        parsedNumber.Add(currentChar);
                        index++;
                    }
                    else
                    {
                        isEndOfNumber = true;
                    }
                }
            }

            char[] splittedOperand = parsedNumber.ToArray();
            double firstOperand = this.GetNumber(splittedOperand);

            return firstOperand;
        }

        #endregion
    }
}
