using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado
{
    public class Uf
    {
        private readonly string[] estadosBrasileiros = new string[] { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" };
        public string SiglaEstado { get;}
        private Uf(string estado)
        {
            if (!estadosBrasileiros.Contains(estado)) throw new InvalidOperationException("UF inválida!");
            SiglaEstado = estado;
        }

        public static Uf Novo(string estado)
        {            
            return new Uf(estado);
        }
    }
}
