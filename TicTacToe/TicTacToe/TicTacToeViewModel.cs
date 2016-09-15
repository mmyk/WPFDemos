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
            Player1 = new Player("Player X", "X");
            Player2 = new Player("Player O", "O");
            Player1.MarkColor = new SolidColorBrush(Colors.Red);
            Player2.MarkColor = new SolidColorBrush(Colors.Green);

            Game = new Game(Player1);

            TakeTurn = new TakeTurnCommand(this);
        }
    }
}
