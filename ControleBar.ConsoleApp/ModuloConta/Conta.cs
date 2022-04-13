using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloCliente
{
    public class Conta : EntidadeBase
    {
        string nomeDoCliente;
        public decimal valorDaConta;
        Garcom garcomDaMesa;
        public bool aberta;
        public List<Pedido> _pedidos;


        public Conta(string nomeDoCliente)
        {
            this.nomeDoCliente = nomeDoCliente;
            aberta = true;
            _pedidos = new List<Pedido>();
        }

        public void AdicionarPedidos(Pedido pedido)
        {
            _pedidos.Add(pedido);
            
        }
    }
}
