using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IExpressionFilter
    {
        /// <summary>Filters the expression replacing subexpressions if is it necessary.
        /// </summary>
        String FilterExpression(String expression);
    }
}
