using System;
using System.Collections.Generic;
using System.Text;

namespace atividade_1.Entidades
{
    class Dinheiro :Pagamento
    { public static double desconto = 0.10;
        public Guid Id { get; set; }
        //public DateTime Data { get; set; }
        //public decimal ValorCompra { get; set; }
        public double ValorRecebido { get; set; }
        public double Troco { get; set; }
        public double Desconto { get; set; }
        //public decimal ValorFinal { get; set; }
        //public bool Efetuada { get; set; }
        public Dinheiro(double valorCompra, double valorRecebido)
        {
            Valor = valorCompra;
            ValorRecebido = valorRecebido;
            DataTransacao = DateTime.Now;
        }



        public override void Pagar()
        {

            if (Valor > ValorRecebido)
            {
                double diferenca = Valor - ValorRecebido;
                Console.WriteLine("Valor não é suficiente para pagar, faltam: :( " + diferenca);
                Confirmacao = false;
              
            }
            else if (ValorRecebido >= Valor)
            {
                Desconto = (desconto * Valor);
                ValorFinal = Valor - Desconto;
                Troco = ValorRecebido - ValorFinal;
                Confirmacao = true;
                Console.WriteLine("Valor Final com Desconto: " + ValorFinal);
                Console.WriteLine("Teve um desconto de: " + Desconto);
                Console.WriteLine($"Este é o troco, mas se  não quiser receber tudo bem :) {Troco} " );

            }
            base.Pagar();
        }




        






    }
}
