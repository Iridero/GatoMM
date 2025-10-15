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

        public List<Nodo> Hijos { get; set; } = null;

        /// <summary>
        /// Genera la lista de hijos para el objeto Nodo actual 
        /// </summary>
        /// <param name="turno">Indica si es turno de X u O</param>
        /// <param name="profundidad">Indica la profundidad actual</param>
        int GenerarHijos(char turno, bool estaMaximizando, int profundidad = 4)
        {
            for(int i = 0; i < 9; i++)
            {
                if (Estado[i]==' ')
                {
                    Nodo hijo = new Nodo();
                    hijo.Estado=new char[9];
                    hijo.Estado = (char[])Estado.Clone();
                    hijo.Estado[i] = turno;
                    if (Hijos==null) Hijos = new List<Nodo>();
                    Hijos.Add(hijo);
                }
            }
            if (profundidad > 0)
            {
                char t = (turno == 'X') ? 'O' : 'X';
                foreach (Nodo hijo in Hijos)
                {
                    if (!hijo.Gana(turno))
                        hijo.GenerarHijos(t, !estaMaximizando, profundidad -1 );
                }
            }
            else
            {
                foreach (Nodo hijo in Hijos)
                {
                    hijo.CalcularValor();
                }
            }
            if (!estaMaximizando)
            {
                return Hijos.Max(h => h.Valor.Value);
            }
            else
            {
                return Hijos.Min(h => h.Valor.Value);
            }
        }

        private readonly int[,] lineas
            = new int[,]
            {
                {0,1,2 },
                {3,4,5 },
                {6,7,8 },
                {0,3,6 },
                {1,4,7 },
                {2,5,8 },
                {0,4,8 },
                {2,4,6 }
            };

        public void CalcularValor ()
        {
            Valor = 0;
            if (Gana('X'))
            {
                Valor = int.MaxValue;
            }
            else if (Gana('O'))
            {
                Valor = int.MinValue;
            }
            else {
                for (int i = 0; i < 8; i++)
                {
                    if (Estado[lineas[i, 0]] != 'X'
                        && Estado[lineas[i, 1]] != 'X'
                        && Estado[lineas[i, 2]] != 'X')
                    {
                        Valor--;
                    }
                    if (Estado[lineas[i, 0]] != 'O'
                        && Estado[lineas[i, 1]] != 'O'
                        && Estado[lineas[i, 2]] != 'O')
                    {
                        Valor++;
                    }
                }
            }
        }

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
