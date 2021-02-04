using System;
using System.Collections.Generic;
using System.Text;

namespace atividade_1.Entidades
{
    public class Pagamento
    {


        public Pagamento()
        {
            Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public bool Confirmacao { get; set; }

        public double Valor { get; set; }
        public string Cpf { get; set; }
        public double ValorFinal { get; set; }
        public double Desconto { get; set; }

        public virtual void Pagar()
        {
            DataTransacao = DateTime.Now;
            Confirmacao = true;
        }

    }
}
