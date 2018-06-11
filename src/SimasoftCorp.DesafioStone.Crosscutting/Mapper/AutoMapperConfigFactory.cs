using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Aplicacao;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Dominio;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Repositorio;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;
using SimasoftCorp.DesafioStone.WebApi.Util.Mapper.TypeConverters;
using SimasoftCorp.DesafioStone.WebApi.Util.Mapper.TypeConverters.Dominio;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper
{
    public class AutoMapperConfigFactory
    {
        private AutoMapperConfigFactory()
        {

        }

        private static IMapper RegisterProfiles()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AllowNullCollections = true;
                    cfg.AllowNullDestinationValues = true;
                    cfg.CreateMap<Cliente, ClienteDto>().ConvertUsing<ClienteParaClienteDto>();
                    cfg.CreateMap<ClienteDto, Cliente>().ConvertUsing<ClienteDtoParaCliente>();
                    cfg.CreateMap<Cobranca, CobrancaDto>().ConvertUsing<CobrancaParaCobrancaDto>();
                    cfg.CreateMap<CobrancaDto, Cobranca>().ConvertUsing<CobrancaDtoParaCobranca>();
                    cfg.CreateMap<ClCliente, Cliente>().ConvertUsing<ClClienteParaCliente>();
                    cfg.CreateMap<Cliente, ClCliente>().ConvertUsing<ClienteParaClCliente>();
                    cfg.CreateMap<ClCobranca, Cobranca>().ConvertUsing<ClCobrancaParaCobranca>();
                    cfg.CreateMap<Cobranca, ClCobranca>().ConvertUsing<CobrancaParaClCobranca>();
                }
            );

            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        public static IMapper GetMapper()
        {
            return RegisterProfiles();
        }
    }
}