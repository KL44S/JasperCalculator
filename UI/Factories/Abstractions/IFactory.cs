using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Factories.Abstractions
{
    public interface IFactory<T>
    {
        /// <summary>Crates and gets a new T type instance
        /// </summary>
        T CreateAndGetInstance();
    }
}
