using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstractions;
using Business.Implementations;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class ExpressionFilterFactory : IExpressionFilterFactory
    {
        #region Attributes

        private IOperandFounderFactory _operandFounderFactory;

        #endregion

        #region Public methods

        public ExpressionFilterFactory(IOperandFounderFactory operandFounderFactory)
        {
            this._operandFounderFactory = operandFounderFactory;
        }

        public IExpressionFilter CreateAndGetInstance()
        {
            IOperandFounder operandFounder = this._operandFounderFactory.CreateAndGetInstance();

            ExpressionFilter additionFilter = new AdditionFilter(operandFounder);

            ExpressionFilter subtractionFilter = new SubtractionFilter(operandFounder);
            subtractionFilter.NextExpressionFilter = additionFilter;

            ExpressionFilter divisionFilter = new DivisionFilter(operandFounder);
            divisionFilter.NextExpressionFilter = subtractionFilter;

            ExpressionFilter multiplicationFilter = new MultiplicationFilter(operandFounder);
            multiplicationFilter.NextExpressionFilter = divisionFilter;

            return multiplicationFilter;
        }

        #endregion
    }
}
