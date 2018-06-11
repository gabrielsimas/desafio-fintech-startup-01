using AutoMapper;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Repositorio
{
    public class ClClienteParaCliente : ITypeConverter<ClCliente, Cliente>
    {
        public Cliente Convert(ClCliente source, Cliente destination, ResolutionContext context)
        {
            if (source == null) return null;
            destination = Cliente.NovoCliente(Cpf.Novo(source.Cpf), Nome.Novo(source.Nome), Uf.Novo(source.Uf), AutoMapperConfigFactory.GetMapper().Map<List<ClCobranca>,List<Cobranca>>(source.Cobrancas));
            return destination;
        }
    }
}
