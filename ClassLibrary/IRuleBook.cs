using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public interface IRuleBook<T>
    {
        bool CheckPlayIsLegitimate(string gridRef, T piece);
    }
}
