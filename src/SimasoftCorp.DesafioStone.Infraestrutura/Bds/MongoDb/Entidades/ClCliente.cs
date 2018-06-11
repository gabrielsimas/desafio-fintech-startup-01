using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Infraestrutura.Entidades
{
    [Serializable]
    public class ClCliente
    {
        [BsonElement("cpf")]
        public string Cpf { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("uf")]
        public string Uf { get; set; }

        [BsonElement("cobrancas")]
        public List<ClCobranca> Cobrancas { get; set; }        
    }
}
