using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public interface IRuleBook
    {
        bool MakePlay(string gridRef, IPieceType piece);
    }
}
