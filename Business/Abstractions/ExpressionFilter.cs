using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public abstract class ExpressionFilter : IExpressionFilter
    {
        //Composite pattern

        #region Properties

        public IExpressionFilter NextExpressionFilter { get; set; }

        #endregion

        #region Protected methods

        protected abstract string DoFilterExpression(string expression);

        #endregion

        #region Public methods

        public string FilterExpression(string expression)
        {
            expression = this.DoFilterExpression(expression);
            
            if (this.NextExpressionFilter != null)
            {
                expression = this.NextExpressionFilter.FilterExpression(expression);
            }

            return expression;
        }

        #endregion
    }
}
