using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TicTacToe
{
    public class Player
    {
        public Player(String Name, String Mark)
        {
            this.Name = Name;
            this.Mark = Mark;
            this.MarkColor = new SolidColorBrush(Colors.Black);
        }

        public String Name { get; set; }

        public String Mark { get; set; }

        public Brush MarkColor { get; set; }
    }
}
