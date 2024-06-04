using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class chrPlayer
    {
        public string playerSymbol  = "";
        public Color foreColor;

        public chrPlayer() 
        { 
        }

        public chrPlayer(string newPlayerSymbol, Color newForeColor)
        {
            playerSymbol = newPlayerSymbol;
            foreColor = newForeColor;
        }
    }
}
