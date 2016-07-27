using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TicTacToe
{
    public class TicTacToeViewModel
    {
        public Game Game { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }
        
        public ICommand TakeTurn { get; set; }

        public TicTacToeViewModel()
        {
            Player1 = new Player("Player 1", "X");
            Player2 = new Player("Player 2", "O");
            Player1.MarkColor = new SolidColorBrush(Colors.Red);
            Player2.MarkColor = new SolidColorBrush(Colors.Green);

            Game = new Game(Player1);

            TakeTurn = new TakeTurnCommand(this);
        }
    }
}
