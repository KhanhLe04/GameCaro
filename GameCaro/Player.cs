using System.Drawing;

namespace GameCaro
{
    internal class Player
    {
        private string name;
        private Image symbol;
        public string Name { get => name; set => name = value; }
        public Image Symbol { get => symbol; set => symbol = value; }

        public Player(string name, Image symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
