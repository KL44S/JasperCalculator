using Business.Abstractions;
using Business.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class OperandFounderFactory : IOperandFounderFactory
    {
        public IOperandFounder CreateAndGetInstance()
        {
            IOperandFounder operandFounder = new OperandFounder();

            return operandFounder;
        }
    }
}
