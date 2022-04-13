using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloPedido;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloCliente
{
    public class TelaCadastroConta : TelaBase
    {
        private readonly TelaCadastroProduto telaCadatroProduto;
        private readonly RepositorioProduto repositorioProduto;
        private readonly IRepositorio<Conta> _repositorioConta;
        private readonly Notificador _notificador;
       

        public TelaCadastroConta(IRepositorio<Conta> repositorioCliente, Notificador notificador)
            : base("Cadastro de Conta")
        {
            _repositorioConta = repositorioCliente;
            _notificador = notificador;
        }

        public override string MostrarOpcoes()
        {

            Console.WriteLine("Digite 1 para Abrir Conta");
            Console.WriteLine("Digite 2 para Adicionar Pedidos");
            Console.WriteLine("Digite 3 para Fechar Conta");
            Console.WriteLine("Digite 4 para Visualizar Contas em Aberto");
            Console.WriteLine("Digite 5 para Total faturado no dia");
            Console.WriteLine("Digite 6 para Total de gorjetas recebidos no dia");
            

            Console.WriteLine("Digite s para sair");


            string opcao = Console.ReadLine();

            return opcao;
        }


        public void Inserir()
        {
            MostrarTitulo("Cadastro de Conta");

            Conta novaConta = ObterConta();

            _repositorioConta.Inserir(novaConta);

            _notificador.ApresentarMensagem("Conta cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void AdicionarPedido()
        {
            VisualizarRegistros("Pesquisando");

            Console.WriteLine("Selecione a Conta:");
            int numeroContaSelecionada = ObterNumeroRegistro();

            Conta contaSelecionada=_repositorioConta.SelecionarRegistro(numeroContaSelecionada);

            MostrarTitulo("Adicionando Pedidos");

            bool temRegistrosCadastrados =VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma conta cadastrada.", TipoMensagem.Atencao);
                return;
            }

            int numeroConta = ObterNumeroRegistro();
            
            bool temprodutosDisponiveis = telaCadatroProduto.VisualizarRegistros("");

            if (!temprodutosDisponiveis)
            {
                _notificador.ApresentarMensagem("Não há nenhum produto disponivel para cadastrar o pedido", TipoMensagem.Atencao);
                return;
            }

            contaSelecionada.AdicionarPedidos(ObeterPedido());

            
        }

        public void FecharConta()
        {
            VisualizarRegistros("");

            Console.WriteLine("Digite o ID da conta que deseja fechar");
            int numeroContaSelecionada = Convert.ToInt32(Console.ReadLine());

            Conta contaSelecionada = _repositorioConta.SelecionarRegistro(numeroContaSelecionada);

            
            TotalDaConta(contaSelecionada);

            Console.WriteLine("o total da conta é: R$" +contaSelecionada.valorDaConta);
            contaSelecionada.aberta = false;

        }

        public void ContasEmAberto()
        {
            List<Conta> contasEmAberto = new List<Conta>();
            List<Conta> contas = _repositorioConta.SelecionarTodos();

            foreach(Conta conta in contas)
            {
                if(conta.aberta)
                {
                 contasEmAberto.Add(conta);
                }
            }

        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contas Cadastradas");

            List<Conta> contas = _repositorioConta.SelecionarTodos();

            if (contas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma Conta disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Conta conta in contas)
                Console.WriteLine(conta.ToString());

            Console.ReadLine();

            return true;
        }

        private Conta ObterConta()
        {
            Console.Write("Digite nome do Cliente: ");
            string nomeDoCliente = Console.ReadLine();

            //Console.Write("Digite o CPF do garçom: ");
            //string cpf = Console.ReadLine();

            return new Conta(nomeDoCliente);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da Conta que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioConta.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da mesa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        public Pedido ObeterPedido()
        {
            List<Produto> produtos = new List<Produto>();

            Console.WriteLine("Quantos produtos quer adicionar nesse pedido?");
            int numeroDeProdutos = Convert.ToInt32(Console.ReadLine());
            int contador = 0;
            decimal valorDoPedido = 0;
            do
            {
                telaCadatroProduto.VisualizarRegistros("");

                Console.WriteLine("digite o id do produto que vai adicionar");
                int produtoSelecionado=Convert.ToInt32(Console.ReadLine());
                
                Produto produto = repositorioProduto.SelecionarRegistro(produtoSelecionado);
                produtos.Add(produto);
                valorDoPedido += produto.valorDoProduto;

            } while (contador != numeroDeProdutos);

            return new Pedido(produtos,valorDoPedido);
        }

        public void TotalDaConta(Conta conta)
        {
            foreach(Pedido pedido in conta._pedidos)
            {
                conta.valorDaConta += pedido.valorDoPedido;
            }
        }

    }
}
