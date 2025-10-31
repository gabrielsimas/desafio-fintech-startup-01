namespace Simasoft.Desafios.Fintech.Tdd
{
    public class FuncionarioTests
    {
        [Theory]
        [MemberData(nameof(DadosFuncionarios))]
        public void DeveCalcularFaixaSalarialETempoDeAdmissaoCorretamente(string matricula, string nome, string area, string cargo, double salarioBruto, DateOnly dataAdmissao, double faixaSalarialEsperada, int tempoAdmissaoEsperado)
        {
            // Arrange
            var funcionario = Funcionario.Criar(matricula, nome, area, cargo, salarioBruto, dataAdmissao);

            // Act
            var faixaSalarial = funcionario.FaixaSalarial;
            var tempoAdmissao = funcionario.TempoAdmissao;

            // Assert
            Assert.Equal(faixaSalarialEsperada, faixaSalarial, 2);
            Assert.Equal(tempoAdmissaoEsperado, tempoAdmissao);
        }

        [Theory]
        [MemberData(nameof(DadosParaCalculoPlr))]
        public void DeveCalcularPlrCorretamente(string matricula, string nome, string area, string cargo, double salarioBruto, DateOnly dataAdmissao, double plrEsperado)
        {
            // Arrange
            var funcionario = Funcionario.Criar(matricula, nome, area, cargo, salarioBruto, dataAdmissao);
            var calculadora = new CalculadoraPlr(funcionario);

            // Act
            var plrCalculado = calculadora.Calcular();

            // Assert
            Assert.Equal(plrEsperado, plrCalculado, 2);
        }

        public static IEnumerable<object[]> DadosFuncionarios()
        {
            yield return new object[] { "0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.2, new DateOnly(2012, 1, 5), 8.36, 13 };
            yield return new object[] { "0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52, new DateOnly(2015, 1, 5), 0.92, 10 };
            yield return new object[] { "0008174", "Sherman Hodges", "Relacionamento com o Cliente", "Líder de Relacionamento", 3899.74, new DateOnly(2015, 6, 7), 2.57, 10 };
            yield return new object[] { "0007463", "Charlotte Romero", "Financeiro", "Contador Pleno", 3199.82, new DateOnly(2018, 1, 3), 2.11, 7 };
            yield return new object[] { "0005253", "Wong Austin", "Financeiro", "Economista Júnior", 2215.04, new DateOnly(2016, 8, 27), 1.46, 9 };
            yield return new object[] { "0004867", "Danielle Blanchard", "Diretoria", "Auxiliar Administrativo", 2768.28, new DateOnly(2015, 10, 17), 1.82, 10 };
            yield return new object[] { "0001843", "Daugherty Kramer", "Serviços Gerais", "Atendente de Almoxarifado", 2120.08, new DateOnly(2016, 4, 21), 1.40, 9 };
            yield return new object[] { "0007961", "Francesca Hewitt", "Contabilidade", "Auxiliar de Contabilidade", 2101.68, new DateOnly(2015, 6, 21), 1.38, 10 };
            yield return new object[] { "0006806", "Ella Hale", "Diretoria", "Auxiliar Administrativo", 2571.73, new DateOnly(2014, 7, 27), 1.69, 11 };
            yield return new object[] { "0005961", "Jillian Odonnell", "Contabilidade", "Contador Júnior", 2671.26, new DateOnly(2016, 9, 8), 1.76, 9 };
            yield return new object[] { "0007293", "Morton Battle", "Contabilidade", "Economista Pleno", 4457, new DateOnly(2017, 10, 19), 2.94, 8 };
            yield return new object[] { "0002105", "Dorthy Lee", "Financeiro", "Estagiário", 1491.45, new DateOnly(2015, 3, 16), 0.98, 10 };
            yield return new object[] { "0000273", "Petersen Coleman", "Financeiro", "Estagiário", 1426.13, new DateOnly(2016, 9, 20), 0.94, 9 };
            yield return new object[] { "0007361", "Avila Kane", "Contabilidade", "Auxiliar Administrativo", 2166.25, new DateOnly(2016, 9, 16), 1.43, 9 };
            yield return new object[] { "0004237", "Hess Sloan", "Relacionamento com o Cliente", "Atendente", 2266.46, new DateOnly(2014, 10, 27), 1.49, 11 };
            yield return new object[] { "000538", "Ashlee Wood", "Contabilidade", "Auxiliar Administrativo", 2330.19, new DateOnly(2014, 7, 15), 1.54, 11 };
            yield return new object[] { "0014319", "Abraham Jones", "Diretoria", "Diretor Tecnologia", 18053.25, new DateOnly(2016, 7, 5), 11.89, 9 };
            yield return new object[] { "0006335", "Beulah Long", "Tecnologia", "Jovem Aprendiz", 1019.88, new DateOnly(2014, 8, 27), 0.67, 11 };
            yield return new object[] { "0007676", "Maricela Martin", "Serviços Gerais", "Copeiro", 1591.69, new DateOnly(2018, 1, 17), 1.05, 7 };
            yield return new object[] { "0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 5694.14, new DateOnly(2014, 1, 26), 3.75, 11 };
            yield return new object[] { "0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", 1800.16, new DateOnly(2017, 3, 31), 1.19, 8 };
            yield return new object[] { "0006877", "Cross Perkins", "Relacionamento com o Cliente", "Líder de Ouvidoria", 3371.47, new DateOnly(2016, 12, 6), 2.22, 8 };
            yield return new object[] { "0010001", "Peter Jones", "Tecnologia", "Desenvolvedor", 8500.00, new DateOnly(2019, 5, 20), 5.60, 6 };
            yield return new object[] { "0010002", "Mary Williams", "Financeiro", "Analista Financeiro", 6200.00, new DateOnly(2021, 2, 10), 4.08, 4 };
            yield return new object[] { "0010003", "John Smith", "Diretoria", "Diretor", 25000.00, new DateOnly(2015, 1, 15), 16.47, 10 };
            yield return new object[] { "0010004", "Sue Miller", "Serviços Gerais", "Auxiliar de Limpeza", 1800.00, new DateOnly(2023, 8, 1), 1.19, 2 };
            yield return new object[] { "0010005", "Tom Wilson", "Relacionamento com o Cliente", "Atendente", 2500.00, new DateOnly(2022, 11, 30), 1.65, 2 };
            yield return new object[] { "0010006", "Ann Brown", "Contabilidade", "Contador", 7000.00, new DateOnly(2018, 9, 1), 4.61, 7 };
            yield return new object[] { "0010007", "Mike Davis", "Tecnologia", "DBA", 9500.00, new DateOnly(2017, 7, 15), 6.26, 8 };
            yield return new object[] { "0010008", "Liz Moore", "Financeiro", "Estagiário", 1400.00, new DateOnly(2024, 1, 1), 0.92, 1 };
            yield return new object[] { "0010009", "Peter Taylor", "Diretoria", "Presidente", 30000.00, new DateOnly(2012, 1, 1), 19.76, 13 };
            yield return new object[] { "0010010", "Mary Anderson", "Relacionamento com o Cliente", "Líder de Atendimento", 4500.00, new DateOnly(2020, 12, 1), 2.96, 4 };
        }

        public static IEnumerable<object[]> DadosParaCalculoPlr()
        {
            yield return new object[] { "0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.2, new DateOnly(2012, 1, 5), 182825.28 };
            yield return new object[] { "0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52, new DateOnly(2015, 1, 5), 117307.68 };
            yield return new object[] { "0008174", "Sherman Hodges", "Relacionamento com o Cliente", "Líder de Relacionamento", 3899.74, new DateOnly(2015, 6, 7), 467968.8 };
            yield return new object[] { "0007463", "Charlotte Romero", "Financeiro", "Contador Pleno", 3199.82, new DateOnly(2018, 1, 3), 191989.2 };
            yield return new object[] { "0005253", "Wong Austin", "Financeiro", "Economista Júnior", 2215.04, new DateOnly(2016, 8, 27), 186063.36 };
            yield return new object[] { "0004867", "Danielle Blanchard", "Diretoria", "Auxiliar Administrativo", 2768.28, new DateOnly(2015, 10, 17), 199316.16 };
            yield return new object[] { "0001843", "Daugherty Kramer", "Serviços Gerais", "Atendente de Almoxarifado", 2120.08, new DateOnly(2016, 4, 21), 203527.68 };
            yield return new object[] { "0007961", "Francesca Hewitt", "Contabilidade", "Auxiliar de Contabilidade", 2101.68, new DateOnly(2015, 6, 21), 176541.12 };
            yield return new object[] { "0006806", "Ella Hale", "Diretoria", "Auxiliar Administrativo", 2571.73, new DateOnly(2014, 7, 27), 185164.56 };
            yield return new object[] { "0005961", "Jillian Odonnell", "Contabilidade", "Contador Júnior", 2671.26, new DateOnly(2016, 9, 8), 224385.84 };
            yield return new object[] { "0007293", "Morton Battle", "Contabilidade", "Economista Pleno", 4457, new DateOnly(2017, 10, 19), 374388 };
            yield return new object[] { "0002105", "Dorthy Lee", "Financeiro", "Estagiário", 1491.45, new DateOnly(2015, 3, 16), 125281.8 };
            yield return new object[] { "0000273", "Petersen Coleman", "Financeiro", "Estagiário", 1426.13, new DateOnly(2016, 9, 20), 119794.92 };
            yield return new object[] { "0007361", "Avila Kane", "Contabilidade", "Auxiliar Administrativo", 2166.25, new DateOnly(2016, 9, 16), 181965 };
            yield return new object[] { "0004237", "Hess Sloan", "Relacionamento com o Cliente", "Atendente", 2266.46, new DateOnly(2014, 10, 27), 271975.2 };
            yield return new object[] { "000538", "Ashlee Wood", "Contabilidade", "Auxiliar Administrativo", 2330.19, new DateOnly(2014, 7, 15), 195735.96 };
            yield return new object[] { "0014319", "Abraham Jones", "Diretoria", "Diretor Tecnologia", 18053.25, new DateOnly(2016, 7, 5), 259966.8 };
            yield return new object[] { "0006335", "Beulah Long", "Tecnologia", "Jovem Aprendiz", 1019.88, new DateOnly(2014, 8, 27), 85669.92 };
            yield return new object[] { "0007676", "Maricela Martin", "Serviços Gerais", "Copeiro", 1591.69, new DateOnly(2018, 1, 17), 114601.68 };
            yield return new object[] { "0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 5694.14, new DateOnly(2014, 1, 26), 239153.88 };
            yield return new object[] { "0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", 1800.16, new DateOnly(2017, 3, 31), 216019.2 };
            yield return new object[] { "0006877", "Cross Perkins", "Relacionamento com o Cliente", "Líder de Ouvidoria", 3371.47, new DateOnly(2016, 12, 6), 404576.4 };
            yield return new object[] { "0010001", "Peter Jones", "Tecnologia", "Desenvolvedor", 8500.00, new DateOnly(2019, 5, 20), 170000 };
            yield return new object[] { "0010002", "Mary Williams", "Financeiro", "Analista Financeiro", 6200.00, new DateOnly(2021, 2, 10), 186000 };
            yield return new object[] { "0010003", "John Smith", "Diretoria", "Diretor", 25000.00, new DateOnly(2015, 1, 15), 360000 };
            yield return new object[] { "0010004", "Sue Miller", "Serviços Gerais", "Auxiliar de Limpeza", 1800.00, new DateOnly(2023, 8, 1), 108000 };
            yield return new object[] { "0010005", "Tom Wilson", "Relacionamento com o Cliente", "Atendente", 2500.00, new DateOnly(2022, 11, 30), 210000 };
            yield return new object[] { "0010006", "Ann Brown", "Contabilidade", "Contador", 7000.00, new DateOnly(2018, 9, 1), 210000 };
            yield return new object[] { "0010007", "Mike Davis", "Tecnologia", "DBA", 9500.00, new DateOnly(2017, 7, 15), 266000 };
            yield return new object[] { "0010008", "Liz Moore", "Financeiro", "Estagiário", 1400.00, new DateOnly(2024, 1, 1), 50400 };
            yield return new object[] { "0010009", "Peter Taylor", "Diretoria", "Presidente", 30000.00, new DateOnly(2012, 1, 1), 432000 };
            yield return new object[] { "0010010", "Mary Anderson", "Relacionamento com o Cliente", "Líder de Atendimento", 4500.00, new DateOnly(2020, 12, 1), 432000 };
        }
    }
}
