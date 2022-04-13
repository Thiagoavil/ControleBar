using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        
        public decimal valorDoPedido;
        private List<Produto> produtos;

        public Pedido(List<Produto> produtos, decimal valorDoPedido)
        {
            this.produtos = produtos;
            this.valorDoPedido= valorDoPedido;
        }
    }
}
