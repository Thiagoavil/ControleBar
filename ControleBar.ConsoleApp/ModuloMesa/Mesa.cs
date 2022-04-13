using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        string numeroDaMesa;

        public Mesa(string numeroDaMesa)
        {
            this.numeroDaMesa = numeroDaMesa;
        }

    }
}
