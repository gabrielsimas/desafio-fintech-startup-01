using AutoMapper;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Dominio
{
    public class ClienteParaClCliente : ITypeConverter<Cliente, ClCliente>
    {
        public ClCliente Convert(Cliente source, ClCliente destination, ResolutionContext context)
        {
            if (source == null) return null;
            destination = new ClCliente()
            {
                Cpf = source.Cpf.Numero != 0 ? source.Cpf.Numero.ToString() : null,
                Nome = !string.IsNullOrEmpty(source.Nome.Texto) ? source.Nome.Texto: null,
                Uf = !string.IsNullOrEmpty(source.Estado.SiglaEstado) ? source.Estado.SiglaEstado: null,
                Cobrancas = AutoMapperConfigFactory.GetMapper().Map<List<Cobranca>, List<ClCobranca>>(source.Cobrancas)
            };

            return destination;
        }
    }
}
