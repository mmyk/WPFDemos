using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// A collection of Cells that represents a Tic Tac Toe board
    /// </summary>
    public class GameBoard
    {
        public Cell Cell_0_0 { get; set; }
        
        public Cell Cell_0_1 { get; set; }
        
        public Cell Cell_0_2 { get; set; }
        
        public Cell Cell_1_0 { get; set; }
        
        public Cell Cell_1_1 { get; set; }
        
        public Cell Cell_1_2 { get; set; }
        
        public Cell Cell_2_0 { get; set; }
        
        public Cell Cell_2_1 { get; set; }
        
        public Cell Cell_2_2 { get; set; }

        public GameBoard()
        {
            Cell_0_0 = new Cell();
            Cell_0_1 = new Cell();
            Cell_0_2 = new Cell();
            Cell_1_0 = new Cell();
            Cell_1_1 = new Cell();
            Cell_1_2 = new Cell();
            Cell_2_0 = new Cell();
            Cell_2_1 = new Cell();
            Cell_2_2 = new Cell();
        }

        public Boolean HasHorizontalMatch()
        {
            //Horizontal win sets: 
            // { Cell_0_0, Cell_0_1, Cell_0_2 }, 
            // { Cell_1_0, Cell_1_1, Cell_1_2 }, 
            // { Cell_2_0, Cell_2_1, Cell_2_2 }

            if (Cell.AreEqual(Cell_0_0, Cell_0_1, Cell_0_2))
                return true;
            if (Cell.AreEqual(Cell_1_0, Cell_1_1, Cell_1_2))
                return true;
            if (Cell.AreEqual(Cell_2_0, Cell_2_1, Cell_2_2))
                return true;
            return false;
        }

        public Boolean HasVerticalMatch()
        {
            //Vertical win sets:
            // { Cell_0_0, Cell_1_0, Cell_2_0 }, 
            // { Cell_0_1, Cell_1_1, Cell_2_1 }, 
            // { Cell_0_2, Cell_1_2, Cell_2_2 }

            if (Cell.AreEqual(Cell_0_0, Cell_1_0, Cell_2_0))
                return true;
            if (Cell.AreEqual(Cell_0_1, Cell_1_1, Cell_2_1))
                return true;
            if (Cell.AreEqual(Cell_0_2, Cell_1_2, Cell_2_2))
                return true;
            return false;
        }

        public Boolean HasDiagonalMatch()
        {
            //Diagonal win sets:
            // { Cell_0_0, Cell_1_1, Cell_2_2 }, 
            // { Cell_0_2, Cell_1_1, Cell_2_0 }

            if (Cell.AreEqual(Cell_0_0, Cell_1_1, Cell_2_2))
                return true;
            if (Cell.AreEqual(Cell_0_2, Cell_1_1, Cell_2_0))
                return true;
            return false;
        }
    }
}
