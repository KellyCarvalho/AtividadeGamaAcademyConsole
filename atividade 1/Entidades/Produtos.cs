using System;
using System.Collections.Generic;
using System.Text;

namespace atividade_1.Entidades
{
    class Produtos
    {
        public Produtos(int codigoProduto,string nomeProduto, double precoProduto, int estoqueProduto)
        {
            
            NomeProduto = nomeProduto;
            PrecoProduto = precoProduto;
            EstoqueProduto = estoqueProduto;
            CodigoProduto = codigoProduto;

        }

        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int EstoqueProduto { get; set; }


        public void Compra()
        {
            EstoqueProduto -= QuantidadeProduto;

        }


    }


}
