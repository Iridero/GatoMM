using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatoMM
{
    class Nodo
    {
        public int? Valor { get; private set; } = null;

        public char[] Estado { get; private set; } = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        private int[,] lineas
            = new int[,]
            {
                {0,1,2},
                {3,4,5 },
                {6,7,8 },
                {0,3,6 },
                {1,4,7 },
                {2,5,8 },
                {0,4,8 },
                {2,4,6 }
            };

        private bool Gana(char xo)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Estado[lineas[i, 0]]==xo 
                    && Estado[lineas[i, 1]] == xo 
                    && Estado[lineas[i, 2]] == xo)
                {
                    return true;
                }
            }
            return false;
        }
        private string LF = Environment.NewLine;

        public override string ToString()
        {
            return string.Concat
                (
                Estado[0], Estado[1], Estado[2], LF,
                Estado[3], Estado[4], Estado[5], LF,
                Estado[6], Estado[7], Estado[8], LF
                );
        }
    }
}
