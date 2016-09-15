using System;
using System.ComponentModel;
using System.Windows;

namespace TicTacToe
{
    public class Game : INotifyPropertyChanged
    {
        const int MIN_TURNS = 1;
        const int MAX_TURNS = 9;

        private GameBoard _Board;
        public GameBoard Board { get { return _Board; } set { if (_Board != value) { _Board = value; OnPropertyChanged(nameof(Board)); } } }
        
        private Player _CurrentPlayer;
        public Player CurrentPlayer { get { return _CurrentPlayer; } set { if (_CurrentPlayer != value) { _CurrentPlayer = value; OnPropertyChanged(nameof(CurrentPlayer)); } } }

        private int _Turn;
        public int Turn { get { return _Turn; } set { if (_Turn != value) { _Turn = value; OnPropertyChanged(nameof(Turn)); } } }

        private Boolean _HasWinner;
        public Boolean HasWinner { get { return _HasWinner; } set { if (_HasWinner != value) { _HasWinner = value; OnPropertyChanged(nameof(HasWinner)); } } }

        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(String propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public Game(Player starter)
        {
            Initialize(starter);
        }

        public void Initialize(Player starter)
        {
            Board = new GameBoard();
            CurrentPlayer = starter;
            Turn = 1;
            HasWinner = false;
        }

        public void Restart(Player starter)
        {
            Initialize(starter);
        }

        public void End()
        {
            Application.Current.Shutdown();
        }

        public Boolean IsGameOver()
        {
            if (Board.HasHorizontalMatch() ||
                Board.HasVerticalMatch() ||
                Board.HasDiagonalMatch())
            {
                HasWinner = true;
                return true;
            }
            else if (this.Turn > MAX_TURNS)
            {
                HasWinner = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
