using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado
{
    public class Nome
    {
        public string Texto { get; }
        private Nome(string nome)
        {
            Texto = nome;
        }

        public static Nome Novo(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new InvalidOperationException("O nome não pode ser nulo!");
            return new Nome(nome);
        }
    }
}
