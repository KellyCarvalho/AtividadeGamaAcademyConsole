
using atividade_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Girls.Gama2
{
    class Program
    {
        private static List<Boleto> listaBoletos;
        private static List<Dinheiro> historicoAVista;
        private static List<Produtos> produtosComprados;
        private static Produtos tv = new Produtos(1,"Televisão", 1800.00, 500);
        private static Produtos geladeira = new Produtos(2,"Geladeira", 4900.00, 600);
        private static double ValorCompra;


        static void Main(string[] args)
        {  
        listaBoletos = new List<Boleto>();
            historicoAVista = new List<Dinheiro>();
            produtosComprados = new List<Produtos>();
            ValorCompra = 0;

            Produtos tv = new Produtos(1,"Televisão", 1800.00, 500);
            Produtos geladeira = new Produtos(2,"Geladeira", 4900.00, 600);



            while (true)
            {
                ComprarProdutos();
                Console.WriteLine("================== Loja das meninas da Gama Academy ============================");
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1-Compra a boleto | 2-Pagamento Boleto | 3-Relatório Boletos | 4 - Compra À Vista | 5 - Histórico de Compras À Vista");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Comprar();
                        break;
                    case 2:
                        Pagamento();
                        break;
                    case 3:
                        Relatorio();
                        break;
                    case 4:
                        PagamentoAVista();
                      break;
                    case 5:
                        HistoricoPagamentoAVista();
                        break;


                    default:
                        break;
                }
            }
        }

      public static void  HistoricoPagamentoAVista()
        {
            Console.WriteLine("Informe o Histórico que deseja: 1 - Vendas À Vista efetuadas com sucesso | 2 - Vendas À Vista Canceladas | 3 - Todas as Vendas À Vista");
            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    HistoricoPagamentoAVistaEfetuados();
                    break;
                case 2:
                    HistoricoPagamentoAVistaCancelados();
                    break;
                case 3:
                    HistoricoTodosPagamentoAVista();
                    break;
                default:
                    break;


            }


        }

        public static void EscolherProdutos()
        {
            
            double desconto = 0;
            double soma = 0;
    
            foreach (var item in produtosComprados)
            {
                if (item.CodigoProduto == 1)
                {
                    Console.WriteLine($"Parabéns vc comprou {item.QuantidadeProduto} {item.NomeProduto} (s)");
                    Console.WriteLine("Nome: " + item.NomeProduto);
                    Console.WriteLine("Quantidade: " + item.QuantidadeProduto);
                    Console.WriteLine("Preço: " + item.PrecoProduto);
                    soma = item.PrecoProduto * item.QuantidadeProduto;
                    desconto = soma * 0.15;
                    ValorCompra = soma - desconto;
                    Console.WriteLine("Soma do Produto Com desconto: " + ValorCompra);

                }
                else if (item.CodigoProduto == 2)
                {
                    Console.WriteLine($"Parabéns vc comprou {item.QuantidadeProduto} {item.NomeProduto} (s)");
                    Console.WriteLine("Nome: "+item.NomeProduto);
                    Console.WriteLine("Quantidade: " + item.QuantidadeProduto);
                    Console.WriteLine("Preço: " + item.PrecoProduto);
                    soma = item.PrecoProduto * item.QuantidadeProduto;
                    Console.WriteLine("Soma do(s) Produto(s) Sem desconto: " + soma);
                    desconto = soma * 0.15;
                    ValorCompra = (soma - desconto)-100.0;
                    Console.WriteLine("Soma do(s) Produto(s) Com desconto: " + ValorCompra);

                }

            }
        }
        public static void PagamentoAVista()
        {

            Console.WriteLine("À vista você ainda tem 10% de desconto no valor final da sua compra :) ");
            Console.WriteLine("O total da Sua compra foi: "+ValorCompra);
            Console.WriteLine("Informe o valor recebido: ");
            double valorRecebido = Double.Parse(Console.ReadLine());
            var pagamentoAvista = new Dinheiro(ValorCompra, valorRecebido);
            pagamentoAvista.Pagar();
            historicoAVista.Add(pagamentoAvista);



        }
       public static void HistoricoTodosPagamentoAVista()
        {
            var historico = historicoAVista.ToList();
            foreach (var item in historico)
            {
                Console.WriteLine($" Data do Pagamento: {item.DataTransacao}, Valor Recebido: {item.ValorRecebido}, Total do Desconto: {item.Desconto}, Valor Final: {item.ValorFinal}");
            }
        }
        public static void HistoricoPagamentoAVistaEfetuados()
        {
            var historico = historicoAVista.Where(item => item.Confirmacao).ToList();
            foreach(var item in historico)
            {
                Console.WriteLine($" Data do Pagamento: {item.DataTransacao}, Valor da Compra: {item.Valor}, Valor Recebido: {item.ValorRecebido}, Total do Desconto: {item.Desconto}, Valor Final: {item.ValorFinal}");
            }

        }
        public static void HistoricoPagamentoAVistaCancelados()
        {
            var historico = historicoAVista.Where(item => item.Confirmacao == false).ToList();
            foreach (var item in historico)
            {
                Console.WriteLine($" Data do Pagamento: {item.DataTransacao}, Valor da Compra: {item.Valor}, Valor Recebido: {item.ValorRecebido}, Total do Desconto: {item.Desconto}, Valor Final: {item.ValorFinal}");
            }

        }
        public static void Comprar()
        {
            Console.WriteLine("O valor da Sua compra foi:  "+ValorCompra);
           

            Console.WriteLine("Digite o CPF do cliente:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Preeencha uma descrição caso necessário");
            var descricao = Console.ReadLine();

            var boleto = new Boleto(cpf, ValorCompra, descricao);
            boleto.GerarBoleto();

            Console.WriteLine($"Boleto gerado com sucesso com o número {boleto.CodigoBarra} com data de vencimento para o dia {boleto.DataVencimento} ");

            listaBoletos.Add(boleto);
        }

        public static void Pagamento()
        {
            Console.WriteLine("Digite o código de barras:");
            var numero = Guid.Parse(Console.ReadLine());

            var boleto = listaBoletos
                            .Where(item => item.CodigoBarra == numero)
                            .FirstOrDefault();

            if (boleto is null)
            {
                Console.WriteLine($"Boleto de código {numero} não encontrado!");
                return;
            }

            if (boleto.EstaPago())
            {
                Console.WriteLine($"Boleto já foi pago no dia {boleto.DataPagamento}");
                return;
            }

            if (boleto.EstaVencido())
            {
                boleto.CalcularJuros();
                Console.WriteLine($"Boleto está vencido, terá acrescimo de 10% === R$ {boleto.Valor}");
            }

            boleto.Pagar();
            Console.WriteLine($"Boleto de código {numero} foi pago com sucesso");
        }

        public static void Relatorio()
        {
            Console.WriteLine("Qual opção de relatório:");
            Console.WriteLine("1-Pagos | 2-À pagar | 3-Vencidos");

            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    BoletosPagos();
                    break;
                case 2:
                    BoletosAPagar();
                    break;
                case 3:
                    BoletosVencidos();
                    break;
                default:
                    break;
            }
        }

        public static void BoletosPagos()
        {
            Console.WriteLine("========== Boletos pagos ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos pagos ============ \n");
        }

        public static void BoletosAPagar()
        {
            Console.WriteLine("========== Boletos à pagar ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao == false
                                    && item.DataVencimento > DateTime.Now)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos à pagar ============ \n");
        }

        public static void BoletosVencidos()
        {
            Console.WriteLine("========== Boletos vencidos ============");
            var boletos = listaBoletos
                            .Where(item => item.Confirmacao == false
                                    && item.DataVencimento < DateTime.Now)
                            .ToList();

            foreach (var item in boletos)
            {
                Console.WriteLine("\n ====");
                Console.WriteLine($"Codigo de Barra: {item.CodigoBarra}\nValor:{item.Valor}\nData Pagamento: {item.DataPagamento} ==");
            }

            Console.WriteLine("========== Boletos vencidos ============ \n");
        }


        public static void ComprarProdutos()
        {
             
            Console.WriteLine("Mega Promoção!!!!!");
            Console.WriteLine("TVs e Geladeiras com Desconto");
            Console.WriteLine("Tvs com 15% de Desconto");
            Console.WriteLine("Geladeiras com 15% de Desconto e ainda descontamos 100 reais");
            Console.WriteLine("Corra! Aproveite!!!");
            Console.WriteLine($"TV Preço: {tv.PrecoProduto}, Quantidade Restante: {tv.EstoqueProduto}");
            Console.WriteLine($"Geladeira Preço: {geladeira.PrecoProduto}, Quantidade Restante: {geladeira.EstoqueProduto}");
            Console.WriteLine("Informe a opção que deseja: 1 - TV | 2 - Geladeira | 3 - Não deseja os Produtos em Promoção");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                Console.WriteLine("Informe a quantidade de TVs");
                int quantidade = int.Parse(Console.ReadLine());
                tv.QuantidadeProduto = quantidade;
                produtosComprados.Add(tv);
                tv.Compra();
              

            }else if(opcao==2){
                Console.WriteLine("Informe a quantidade de Geladeiras");
                int quantidade = int.Parse(Console.ReadLine());
                geladeira.QuantidadeProduto = quantidade;
                produtosComprados.Add(geladeira);
                var ver = produtosComprados.ToList();
                foreach(var item in ver)
                {
                    Console.WriteLine($"Produto: {item.PrecoProduto}");
                }
                
                geladeira.Compra();
            }
            else
            {
                Console.WriteLine("Desculpe de decepcionar tentarei melhorar da próxima vez :(");
                return;
            }
            
            EscolherProdutos();

        }

        

    }
}

