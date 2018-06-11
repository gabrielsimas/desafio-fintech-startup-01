using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado
{
    public class Cpf: ObjetoDeValor<Cpf>
    {
        public long Numero { get; }

        private Cpf(string numeroDoDocumento)
        {            
            Numero = long.Parse(TrataCpf(numeroDoDocumento));
        }

        public static Cpf Novo(string numeroDoDocumento)
        {
            if (!CpfValido(numeroDoDocumento)) throw new InvalidOperationException(string.Format("Cpf {0} inválido",numeroDoDocumento));
            if (string.IsNullOrEmpty(numeroDoDocumento)) throw new InvalidOperationException("Cpf não pode ser vazio!");                
                return new Cpf(numeroDoDocumento);            
        }

        public static string TrataCpf(string numeroDoDocumento)
        {
            Regex validacao = new Regex(@"[^\d]");
            string somenteDigitos = validacao.Replace(numeroDoDocumento, "");
            return somenteDigitos;
        }

        public static bool CpfValido(string numeroDoDocumento)
        {
            string somenteDigitos;
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{6}$");

            somenteDigitos = TrataCpf(numeroDoDocumento);

            //Aqui já invalida o CPF, caso tenha menos de 11 dígitos ou se existirem mais de 6 digitos iguais
            if (duplicatas.IsMatch(somenteDigitos)) return false;
            if (!validaTamanho.IsMatch(somenteDigitos)) return false;

            int valorFinal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2));            
            int valorJGerado = 0;
            int valorKGerado = 0;

            int somaJ = 0;
            int somaK = 0;

            //Calcula para J
            for (int i = somenteDigitos.Length - 1; i >= 2; i--)
            {
                //Pega a ordem inversa para iterar a listagem
                int j = 10 - i;
                somaJ += int.Parse(somenteDigitos[j].ToString()) * i;
            }

            //Dividimos a soma por 11 para validar J
            var restoDadivisaoDeJporOnze = somaJ % 11;

            if (restoDadivisaoDeJporOnze == 0 || restoDadivisaoDeJporOnze == 1)
            {
                valorJGerado = 0;
            }
            else if (restoDadivisaoDeJporOnze >= 2 && restoDadivisaoDeJporOnze <= 10)
            {
                valorJGerado = 11 - restoDadivisaoDeJporOnze;
            }

            //Calcula para K
            for (int i = somenteDigitos.Length; i >= 2; i--)
            {
                //Pega a ordem inversa para iterar a listagem
                int k = somenteDigitos.Length - i;
                somaK += int.Parse(somenteDigitos[k].ToString()) * i;
            }

            //Dividimos a soma por 11 para validar J
            var restoDadivisaoDeKporOnze = somaK % 11;

            if (restoDadivisaoDeKporOnze == 0 || restoDadivisaoDeKporOnze == 1)
            {
                valorKGerado = 0;
            }
            else if (restoDadivisaoDeKporOnze >= 2 && restoDadivisaoDeKporOnze <= 10)
            {
                valorKGerado = 11 - restoDadivisaoDeKporOnze;
            }

            return valorFinal == int.Parse(valorJGerado.ToString() + valorKGerado.ToString());
        }

        protected override bool EqualsCore(Cpf other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
