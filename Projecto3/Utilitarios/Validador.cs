using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ficha3.Modelos;

namespace Ficha3.Utilitarios
{
    public class Validador
    {
        public static bool Validar(Produto produto)
        {
            if (produto.Nome.Length < 3)
            {
                return false;
            }
            return true;


        }
    }
}
