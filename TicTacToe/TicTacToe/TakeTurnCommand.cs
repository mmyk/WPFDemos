using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TicTacToe
{
    public class TakeTurnCommand : ICommand
    {
        private TicTacToeViewModel viewModel;
        public event EventHandler CanExecuteChanged;

        public TakeTurnCommand(TicTacToeViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.Game.PropertyChanged += ViewModel_PropertyChanged; 
        }

        public bool CanExecute(object parameter)
        {
            //TakeTurn can execute when initializing or when changing Cell values, but not when the game is over!
            if (parameter == null)
            {
                return true;
            }
            else
            {
                if (this.viewModel.Game.IsGameOver())
                    return false;

                var cell = (Cell)parameter;
                return cell.Value == null;
            }
            
        }

        public void Execute(object parameter)
        {
            var game = this.viewModel.Game;

            //Mark the clicked Cell with CurrentPlayer's Mark
            var cell = (Cell)parameter;
            cell.Value = game.CurrentPlayer.Mark;
            cell.Foreground = game.CurrentPlayer.MarkColor;

            //Increment the turn
            game.Turn++;

            //Evaluate game state for game over
            if (game.IsGameOver())
            {
                //TODO: Clean up the duplication when evaluating game state for win
                if (game.HasWinner)
                {
                    if (MessageBox.Show(String.Format("{0} Wins! \n\nDo you want to play again?", game.CurrentPlayer.Name), "Game Over", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //Restart the game. Be polite. Loser goes first.
                        if (game.CurrentPlayer.Equals(this.viewModel.Player1))
                        {
                            game.Restart(this.viewModel.Player2);
                        }
                        else
                        {
                            game.Restart(this.viewModel.Player1);
                        }
                    }
                    else
                    {
                        game.End();
                    }
                }
                else
                {
                    if (MessageBox.Show("It's a Draw! \n\nDo you want to play again?", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        //Restart the game. Be polite. Second Player goes first.
                        if (game.CurrentPlayer.Equals(this.viewModel.Player1))
                        {
                            game.Restart(this.viewModel.Player2);
                        }
                        else
                        {
                            game.Restart(this.viewModel.Player1);
                        }
                    }
                    else
                    {
                        game.End();
                    }
                }
            }
            else
            {
                //If the game is not over, change the current player
                if (game.CurrentPlayer.Equals(this.viewModel.Player1))
                {
                    game.CurrentPlayer = this.viewModel.Player2;
                }
                else
                {
                    game.CurrentPlayer = this.viewModel.Player1;
                }
            }
            
        }

        private void ViewModel_PropertyChanged(Object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
    }
}