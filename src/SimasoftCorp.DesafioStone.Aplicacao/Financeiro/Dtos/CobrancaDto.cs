using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos
{
    public class CobrancaDto
    {
        public string Cpf {get; set;}
        public decimal Valor { get; set; }
        public DateTime DataDeVencimento { get; set; }

    }
}
