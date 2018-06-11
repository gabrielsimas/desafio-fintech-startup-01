using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos
{
    public class ClienteDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string DataDeCadastro { get; set; }
    }
}
