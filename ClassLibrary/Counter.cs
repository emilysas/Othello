namespace ClassLibrary
{
    public class Counter : ICounter
    {
        private string _colour;

        public Counter(string colour)
        {
            _colour = colour;
        }

        public string Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }
    }
}
