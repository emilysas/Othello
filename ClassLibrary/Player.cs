
namespace ClassLibrary
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string PlayingColour { get; set; }
    }
}
