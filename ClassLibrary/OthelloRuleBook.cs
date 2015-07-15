using System;
using ClassLibrary;

namespace ClassLibrary
{
    public class RuleBook<T> : IRuleBook<T>
    {
        public bool CheckPlayIsLegitimate(IBoard<T> board, string gridRef, T pieceToPlay)
        {
            throw new NotImplementedException();
        }

    }
}
