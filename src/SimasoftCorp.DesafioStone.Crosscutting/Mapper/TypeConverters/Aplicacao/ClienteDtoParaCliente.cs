using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Aplicacao
{
    public class ClienteDtoParaCliente : ITypeConverter<ClienteDto, Cliente>
    {
        public Cliente Convert(ClienteDto source, Cliente destination, ResolutionContext context)
        {
            if (source == null) return null;
            destination = Cliente.NovoCliente(Cpf.Novo(source.Cpf),Nome.Novo(source.Nome),Uf.Novo(source.Estado));

            return destination;            
        }
    }
}
