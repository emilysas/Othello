
using System.Security;

namespace ClassLibrary
{
    public class Player<T> : INamedThing where T: IPieceType, new()
    {
        private IBoard<T> _board;
        private readonly IRuleBook<T> _rules;

        public Player(string name, IBoard<T> board, IRuleBook<T> rules )
        {
            Name = name;
            _board = board;
            _rules = rules;
        }

        public string Name { get; set; }

        public string PlayingColour { get; set; }

        public bool Play(string gridRef)
        {
            var piece = new T {Colour = PlayingColour};
            return _rules.CheckPlayIsLegitimate(gridRef, piece);
        }
    }
}
