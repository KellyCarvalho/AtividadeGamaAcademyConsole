using System;

namespace atividade_1.Entidades
{
    public class Boleto : Pagamento
    {
       

        public Boleto()
        {
        }

        public Boleto(string cpf, double valor,   string descricao)
        {
           
            Valor = valor;
            Cpf = cpf;
            Descricao = descricao;
        }

        private const int DiasVencimento = 15;
        private const double Juros = 0.10;
        public Guid CodigoBarra { get; set; }
        //public double Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        //public bool Confirmacao { get; set; }
        //public string Cpf { get; set; }
        public string Descricao { get; set; }


    
        public void GerarBoleto()
        {
            CodigoBarra = Guid.NewGuid();
            DataVencimento = DataEmissao.AddDays(DiasVencimento);
        }

        public bool EstaPago()
        {
            return Confirmacao;
        }

        public bool EstaVencido()
        {
            return DataVencimento < DateTime.Now;
        }

        public void CalcularJuros()
        {
            var taxa = Valor * Juros;
            Valor += taxa;
        }

        public override void Pagar()
        {
            DataPagamento = DateTime.Now;
            Confirmacao = true;
            base.Pagar();
        }

        
    }
}
