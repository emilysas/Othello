using System.Collections;
using ClassLibrary;

namespace ClassLibrary
{
    public class Counter : IPieceType
    {
        public string Discription { get; set; }
        public string Colour { get; set; }

        public void Flip()
        {
            Colour = (Colour == "black") ? "white" : "black";
        }

    }

}
