using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace Teste.DesafioStone.NucleoCompartilhado
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ObjetosDeValor
    {        
                
        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Núcleo Compartilhado - Objeto de Valor - CPF")]
        public void ValidacaoDeCpfSoMatematica()
        {
            Regex validacao = new Regex(@"[^\d]");
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{4}$");
            string cpfBruto = "067.893.996-90";
            string somenteDigitos = validacao.Replace(cpfBruto, "");
            
            int valorJOriginal = Math.Abs(int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2)) / 10);
            int valorKOriginal = Math.Abs(int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2)) / 100);
            int valorJGerado = 0;
            int valorKGerado = 0;            

            int somaJ = 0;           
            int somaK = 0;                        
                                    
            //Já elimina a chance de duplicidade e mata a execução aqui mesmo
            //if (validacao.IsMatch(somenteDigitos)) Assert.Fail(string.Format("O Cpf {0} é inválido"));            

            //Calcula para J
            for (int i = somenteDigitos.Length - 1; i >= 2; i--)
            {
                //Pega a ordem inversa para iterar a listagem
                int j = 10 - i;                                
                somaJ += int.Parse(somenteDigitos[j].ToString()) * i;                                                                                           
            }

            //Dividimos a soma por 11 para validar J
            var restoDadivisaoDeJporOnze = somaJ % 11;

            if(restoDadivisaoDeJporOnze == 0 || restoDadivisaoDeJporOnze == 1)
            {
                valorJGerado = 0;
            }
            else if(restoDadivisaoDeJporOnze >= 2 && restoDadivisaoDeJporOnze <= 10)
            {
                valorJGerado = 11 - restoDadivisaoDeJporOnze;
            }

            //Calcula para K
            if (validacao.IsMatch(somenteDigitos)) Assert.Fail(string.Format("O Cpf {0} é inválido"));

            //Calcula para J
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

            Assert.IsTrue(!duplicatas.IsMatch(somenteDigitos) && validaTamanho.IsMatch(somenteDigitos) && valorJGerado == valorJOriginal && valorKGerado == valorKOriginal,string.Format("O cpf {0} é inválido.",somenteDigitos));
        }
        
        [DataRow("185.302.491-00")]
        [DataRow("18530249100")]
        [DataRow("297.276.931-72")]
        [DataRow("29727693172")]
        [DataRow("046.428.359-03")]
        [DataRow("04642835903")]
        [DataRow("023.750.169-47")]
        [DataRow("02375016947")]
        [DataRow("855.826.525-90")]
        [DataRow("669.712.265-00")]
        [DataRow("01646227212")]
        [DataRow("96183390259")]
        [DataRow("63118670282")]
        [DataRow("57212970263")]
        [DataRow("85272175204")]
        [DataRow("84250739287")]
        [DataRow("74390651234")]
        [DataRow("93582803287")]
        [DataRow("84569190200")]
        [DataRow("51914794249")]
        [DataRow("67681530215")]
        [DataRow("51918102287")]
        [DataRow("59925272220")]
        [DataRow("72178507204")]
        [DataRow("85542520200")]
        [DataRow("98089242200")]
        [DataRow("66100313200")]
        [DataRow("51405300230")]
        [DataRow("13187110703")]
        [DataTestMethod]
        [TestCategory("Teste Unitário - Spike - Núcleo Compartilhado - Objeto de Valor - CPF")]
        public void CpfsValidos(string cpfBruto)
        {
            Regex validacao = new Regex(@"[^\d]");
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{6}$");
            //string cpfBruto = "067.893.996-90";
            string somenteDigitos = validacao.Replace(cpfBruto, "");

            int valorFinal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2));
            //int valorKOriginal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 1));
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

            Assert.IsTrue(valorFinal == int.Parse(valorJGerado.ToString() + valorKGerado.ToString()), string.Format("O cpf {0} é inválido.", somenteDigitos));
        }

        [DataTestMethod]
        [DataRow("005.333.839-18")]
        [DataRow("00533383910")]
        [DataRow("030.405.039-35")]
        [DataRow("03040503934")]
        [DataRow("046.428.359-02")]
        [DataRow("04642835913")]
        [DataRow("023.750.169-57")]
        [DataRow("02375016937")]
        [DataRow("855.826.525-91")]
        [DataRow("669.712.265-10")]
        [DataRow("01646227211")]
        [DataRow("96183390269")]
        [DataRow("63118670283")]
        [DataRow("57212970273")]
        [DataRow("85272175206")]
        [DataRow("84250739284")]
        [DataRow("74390651233")]
        [DataRow("93582803297")]
        [DataRow("84569190201")]
        [DataRow("51914794259")]
        [DataRow("67681530214")]
        [DataRow("51918102282")]
        [DataRow("59925272221")]
        [DataRow("72178507294")]
        [DataRow("85542520210")]
        [DataRow("98089242210")]
        [DataRow("66100313201")]
        [DataRow("51405300238")]
        [DataRow("13187110704")] 
        [TestCategory("Teste Unitário - Spike - Núcleo Compartilhado - Objeto de Valor - CPF")]
        public void CpfsInvalidos(string cpfBruto)
        {
            Regex validacao = new Regex(@"[^\d]");
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{6}$");
            //string cpfBruto = "067.893.996-90";
            string somenteDigitos = validacao.Replace(cpfBruto, "");

            int valorFinal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2));
            //int valorKOriginal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 1));
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

            Assert.IsTrue(valorFinal != int.Parse(valorJGerado.ToString() + valorKGerado.ToString()), string.Format("O cpf {0} é inválido.", somenteDigitos));
        }

        [DataTestMethod]
        [DataRow("01646227212")]
        [DataRow("02375016947")]
        [DataRow("04642835903")]
        [DataRow("04642835903")]
        [DataRow("13187110703")]
        [DataRow("29727693172")]
        [DataRow("51914794249")]
        [DataRow("51918102287")]
        [DataRow("57212970263")]
        [DataRow("63118670282")]
        [DataRow("67681530215")]
        [TestCategory("Teste Unitário - Spike - Núcleo Compartilhado - Objeto de Valor - CPF")]
        public void CpfsValidosQueNaoPassaramNoTeste(string cpfBruto)
        {
            Regex validacao = new Regex(@"[^\d]");
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{6}$");
            //string cpfBruto = "067.893.996-90";
            string somenteDigitos = validacao.Replace(cpfBruto, "");

            int valorFinal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2));
            //int valorKOriginal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 1));
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

            Assert.IsTrue(valorFinal == int.Parse(valorJGerado.ToString() + valorKGerado.ToString()), string.Format("O cpf {0} é inválido.", somenteDigitos));
        }

        [DataTestMethod]
        [DataRow("005.333.839-18")]
        [DataRow("00533383910")]
        [DataRow("030.405.039-35")]
        [DataRow("03040503934")]
        [DataRow("046.428.359-02")]
        [DataRow("04642835913")]
        [DataRow("023.750.169-57")]
        [DataRow("02375016937")]
        [DataRow("855.826.525-91")]
        [DataRow("669.712.265-10")]
        [DataRow("01646227211")]
        [DataRow("96183390269")]
        [DataRow("63118670283")]
        [DataRow("57212970273")]
        [DataRow("85272175206")]
        [DataRow("84250739284")]
        [DataRow("74390651233")]
        [DataRow("93582803297")]
        [DataRow("84569190201")]
        [DataRow("51914794259")]
        [DataRow("67681530214")]
        [DataRow("51918102282")]
        [DataRow("59925272221")]
        [DataRow("72178507294")]
        [DataRow("85542520210")]
        [DataRow("98089242210")]
        [DataRow("66100313201")]
        [DataRow("51405300238")]
        [DataRow("13187110704")]
        [TestCategory("Teste Unitário - Spike - Núcleo Compartilhado - Objeto de Valor - CPF")]
        public void CpfsInvalidosRefatorado(string cpfBruto)
        {
            Regex validacao = new Regex(@"[^\d]");
            Regex validaTamanho = new Regex(@"\d{11}");
            Regex duplicatas = new Regex(@"^(.)\1{6}$");
            //string cpfBruto = "067.893.996-90";
            string somenteDigitos = validacao.Replace(cpfBruto, "");

            int valorFinal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 2));
            //int valorKOriginal = int.Parse(somenteDigitos.Substring(somenteDigitos.Length - 1));
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

            Assert.IsTrue(valorFinal != int.Parse(valorJGerado.ToString() + valorKGerado.ToString()), string.Format("O cpf {0} é inválido.", somenteDigitos));
        }
    }
}
