using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstractions;
using Business.Implementations;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class CalculatorFactory : ICalculatorFactory
    {
        #region Attributes

        private IExpressionFilterFactory _expressionFilterFactory;

        #endregion

        #region Public methods

        public CalculatorFactory(IExpressionFilterFactory expressionFilterFactory)
        {
            this._expressionFilterFactory = expressionFilterFactory;
        }

        public ICalculator CreateAndGetInstance()
        {
            IExpressionFilter expressionFilter = this._expressionFilterFactory.CreateAndGetInstance();

            ICalculator calculator = new Calculator(expressionFilter);

            return calculator;
        }

        #endregion

    }
}
