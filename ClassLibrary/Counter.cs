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
            ColourDisplayed = ColourDisplayed == "white" ? "black" : "white";
        }
    }
}
