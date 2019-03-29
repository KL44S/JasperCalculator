using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IOperandFounder
    {
        /// <summary>Gets the first operand from an operation giving its index
        /// </summary>
        double GetFirstOperandFromOperationIndex(string expression, int index);

        /// <summary>Gets the second operand from an operation giving its index
        /// </summary>
        double GetSecondOperandFromOperationIndex(string expression, int index);
    }
}
