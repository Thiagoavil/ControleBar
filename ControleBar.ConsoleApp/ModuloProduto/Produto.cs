using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        string nomeDoProduto;
        public decimal valorDoProduto;

        public Produto(string nomeDoProduto, decimal valorDoProduto)
        {
            this.nomeDoProduto = nomeDoProduto;
            this.valorDoProduto = valorDoProduto;
        }
    }
}
