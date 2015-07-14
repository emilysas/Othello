using System.Collections;

namespace ClassLibrary
{
    public class Counter : ICounter
    {
        public string ColourDisplayed { get; private set; }

        public Counter (string colour)
        {
            ColourDisplayed = colour;
        }

        public void Flip()
        {
            switch (ColourDisplayed)
            {
                case("white") :
                    ColourDisplayed = "black";
                    break;
                case("black") :
                    ColourDisplayed = "white";
                    break;
                case("empty") :
                    ColourDisplayed = "empty";
                    break;
            }
        }
    }
}
