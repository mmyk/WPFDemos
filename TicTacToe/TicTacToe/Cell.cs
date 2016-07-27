using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace TicTacToe
{
    public class Cell : INotifyPropertyChanged
    {
        public Cell()
        {
            this.Foreground = new SolidColorBrush(Colors.Green);
        }

        public string Value { get { return _Value; } set { if (_Value != value) { _Value = value; OnPropertyChanged(nameof(Value)); } } }
		private string _Value;

        private Brush _Foreground;
        public Brush Foreground { get { return _Foreground; } set { if (_Foreground != value) { _Foreground = value; OnPropertyChanged("Foreground"); } } }

        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(String propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public static bool AreEqual(Cell cell1, Cell cell2, Cell cell3)
        {
            //Return false if cell values are all null. That isn't really equal.
            if (cell1.Value == null && cell2.Value == null && cell3.Value == null)
                return false;

            return cell1.Value == cell2.Value && cell1.Value == cell3.Value;
        }
    }
}
