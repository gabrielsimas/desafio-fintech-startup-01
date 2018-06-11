using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using System;

namespace SimasoftCorp.DesafioStone.WebApi.Util.Mapper.TypeConverters.Dominio
{
    public class ClienteParaClienteDto : ITypeConverter<Cliente, ClienteDto>
    {
        public ClienteDto Convert(Cliente source, ClienteDto destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new ClienteDto()
            {
                Cpf = source.Cpf.Numero.ToString(),
                Nome = source.Nome.Texto,
                DataDeCadastro = DateTime.Now.ToString("dd/MM/yyyy"),
                Estado = source.Estado.SiglaEstado
            };            
            return destination;
        }
    }
}