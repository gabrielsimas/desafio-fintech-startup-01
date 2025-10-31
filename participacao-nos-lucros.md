# Desafio - Distribuição dos lucros

---

## Objetivos gerais

### Avaliar o(a) candidato(a) nos conceitos de orientação a objeto, qualidade de código, aplicação de padrões,resiliência, disponibilidade, performance, capacidade de monitoramento, testes em suas diversas formas e o bom uso do git (clareza dos commits, divisão do trabalho e melhores práticas).

## Descrição

### Uma empresa fechou o ano de operação com lucro e deseja reparti-lo entre seus funcionários, com o objetivo de ser justa criou uma regra para a distribuição deste montante por: área, tempo de empresa, e faixa salarial (os funcionários que ganham menos teriam sua participação incrementada).

### Para isso foi solicitado ao time de tecnologia que desenvolva uma API REST, que receba o valor máximo a distribuir, efetue a distribuição dentro do possível para os funcionários já cadastrados, aplicando um conjunto de regras pré-estabelecidas, atentando-se que pode não ser possível distribuir o valor disponibilizado, ou seja, o montante disponibilizado pode ser insuficiente.

### As regras de distribuição são:

## **Regras Gerais**

### Foi estabelecido um peso por área de atuação:

- Peso 1: Diretoria;
- Peso 2: Contabilidade, Financeiro, Tecnologia;
- Peso 3: Serviços Gerais;
- Peso 5: Relacionamento com o Cliente.

### Foi estabelecido um peso por faixa salarial e uma exceção para estagiários:

- Peso 5: Acima de 8 salários mínimos;
- Peso 3: Acima de 5 salários mínimos e menor que 8 salários mínimos;
- Peso 2: Acima de 3 salários mínimos e menor que 5 salários mínimos;
- Peso 1: Todos os estagiários e funcionários que ganham até 3 salários mínimos.

### Foi estabelecido um peso por tempo de admissão:

- Peso 1: Até 1 ano de casa;
- Peso 2: Mais de 1 ano e menos de 3 anos;
- Peso 3: Acima de 3 anos e menos de 8 anos;
- Peso 5: Mais de 8 anos.

Pelas regras estabelecidas a fórmula para se chegar ao bônus de cada funcionário é:
$$\frac{(SB * PTA) + (SB * PAA)}{(PFS)} * 12 \text{ (Meses do Ano)} $$

#### Legenda

- **SB**: _Salário Bruto_
- **PTA**: _Peso por tempo de admissão_
- **PAA**: _Peso por aréa de atuação_
- **PFS**: _Peso por faixa salarial_

#### Input de dados

> Dados dos funcionários (formato json)

```json
[
  {
    "matricula": "0009968",
    "nome": "Victor Wilson",
    "area": "Diretoria",
    "cargo": "Diretor Financeiro",
    "salario_bruto": 12696.2,
    "data_de_admissao": "2012-01-05"
  },
  {
    "matricula": "0004468",
    "nome": "Flossie Wilson",
    "area": "Contabilidade",
    "cargo": "Auxiliar de Contabilidade",
    "salario_bruto": 1396.52,
    "data_de_admissao": "2015-01-05"
  },
  {
    "matricula": "0008174",
    "nome": "Sherman Hodges",
    "area": "Relacionamento com o Cliente",
    "cargo": "Líder de Relacionamento",
    "salario_bruto": 3899.74,
    "data_de_admissao": "2015-06-07"
  },
  {
    "matricula": "0007463",
    "nome": "Charlotte Romero",
    "area": "Financeiro",
    "cargo": "Contador Pleno",
    "salario_bruto": 3199.82,
    "data_de_admissao": "2018-01-03"
  },
  {
    "matricula": "0005253",
    "nome": "Wong Austin",
    "area": "Financeiro",
    "cargo": "Economista Júnior",
    "salario_bruto": 2215.04,
    "data_de_admissao": "2016-08-27"
  },
  {
    "matricula": "0004867",
    "nome": "Danielle Blanchard",
    "area": "Diretoria",
    "cargo": "Auxiliar Administrativo",
    "salario_bruto": 2768.28,
    "data_de_admissao": "2015-10-17"
  },
  {
    "matricula": "0001843",
    "nome": "Daugherty Kramer",
    "area": "Serviços Gerais",
    "cargo": "Atendente de Almoxarifado",
    "salario_bruto": 2120.08,
    "data_de_admissao": "2016-04-21"
  },
  {
    "matricula": "0007961",
    "nome": "Francesca Hewitt",
    "area": "Contabilidade",
    "cargo": "Auxiliar de Contabilidade",
    "salario_bruto": 2101.68,
    "data_de_admissao": "2015-06-21"
  },
  {
    "matricula": "0006806",
    "nome": "Ella Hale",
    "area": "Diretoria",
    "cargo": "Auxiliar Administrativo",
    "salario_bruto": 2571.73,
    "data_de_admissao": "2014-07-27"
  },
  {
    "matricula": "0005961",
    "nome": "Jillian Odonnell",
    "area": "Contabilidade",
    "cargo": "Contador Júnior",
    "salario_bruto": 2671.26,
    "data_de_admissao": "2016-09-08"
  },
  {
    "matricula": "0007293",
    "nome": "Morton Battle",
    "area": "Contabilidade",
    "cargo": "Economista Pleno",
    "salario_bruto": 4457,
    "data_de_admissao": "2017-10-19"
  },
  {
    "matricula": "0002105",
    "nome": "Dorthy Lee",
    "area": "Financeiro",
    "cargo": "Estagiário",
    "salario_bruto": 1491.45,
    "data_de_admissao": "2015-03-16"
  },
  {
    "matricula": "0000273",
    "nome": "Petersen Coleman",
    "area": "Financeiro",
    "cargo": "Estagiário",
    "salario_bruto": 1426.13,
    "data_de_admissao": "2016-09-20"
  },
  {
    "matricula": "0007361",
    "nome": "Avila Kane",
    "area": "Contabilidade",
    "cargo": "Auxiliar Administrativo",
    "salario_bruto": 2166.25,
    "data_de_admissao": "2016-09-16"
  },
  {
    "matricula": "0004237",
    "nome": "Hess Sloan",
    "area": "Relacionamento com o Cliente",
    "cargo": "Atendente",
    "salario_bruto": 2266.46,
    "data_de_admissao": "2014-10-27"
  },
  {
    "matricula": "000538",
    "nome": "Ashlee Wood",
    "area": "Contabilidade",
    "cargo": "Auxiliar Administrativo",
    "salario_bruto": 2330.19,
    "data_de_admissao": "2014-07-15"
  },
  {
    "matricula": "0014319",
    "nome": "Abraham Jones",
    "area": "Diretoria",
    "cargo": "Diretor Tecnologia",
    "salario_bruto": 18053.25,
    "data_de_admissao": "2016-07-05"
  },
  {
    "matricula": "0006335",
    "nome": "Beulah Long",
    "area": "Tecnologia",
    "cargo": "Jovem Aprendiz",
    "salario_bruto": 1019.88,
    "data_de_admissao": "2014-08-27"
  },
  {
    "matricula": "0007676",
    "nome": "Maricela Martin",
    "area": "Serviços Gerais",
    "cargo": "Copeiro",
    "salario_bruto": 1591.69,
    "data_de_admissao": "2018-01-17"
  },
  {
    "matricula": "0002949",
    "nome": "Stephenson Stone",
    "area": "Financeiro",
    "cargo": "Analista de Finanças",
    "salario_bruto": 5694.14,
    "data_de_admissao": "2014-01-26"
  },
  {
    "matricula": "0008601",
    "nome": "Taylor Mccarthy",
    "area": "Relacionamento com o Cliente",
    "cargo": "Auxiliar de Ouvidoria",
    "salario_bruto": 1800.16,
    "data_de_admissao": "2017-03-31"
  },
  {
    "matricula": "0006877",
    "nome": "Cross Perkins",
    "area": "Relacionamento com o Cliente",
    "cargo": "Líder de Ouvidoria",
    "salario_bruto": 3371.47,
    "data_de_admissao": "2016-12-06"
  }
]
```

### **Exemplo do retorno esperado (formato json)**
```json
{
	"participacoes": [
		{
			"matricula": "0009968",
			"nome": "Victor Wilson",
			"valor_da_participacao": 0.0
		}
	],
	"total_de_funcionarios": 0,
	"total_distribuido": 0.0,
	"total_disponibilizado": 0.0,
	"saldo_total_disponibilizado": 0.0
}
```

### Detalhes do retorno

| Campo | Descrição |
| :--- | :----------------- |
| `total_distribuido` | Soma do que foi pago em PL a todos os funcionários |
| `total_disponibilizado` | O valor que a empresa desejava distribuir |
| `saldo_total_disponibilizado` | Total disponibilizado menos o total distribuido |

### Pré-requisitos
- **Todo código deve estar no Github do candidato e deve ser informado ao término**;
- Aplicação deve conter todo o necessário para seu funcionamento, não deve ser necessário instalar qualquer tipo de novo recurso externo, com exceção dos frameworks e pacotes (nugets/ java
packages);
- .Net Core ou Java preferencialmente, mas pode ser na sua linguagem de prefência;
- Restfull Api;
- XUnit/JUnit para testes, ou seu framework de teste de preferência;
- Persistência de livre escolha, como sugestão [Firebase](https://firebase.google.com/products/database), [Redis Cloud](https://redislabs.com/), ou qualquer serviço de nuvem, para
evitar necessidades de instalação.

### Dicas
- Documente as formas de subir e testar seu projeto no seu README
- Surpreenda-nos e lembre-se menos é mais!
- Nomes são uma das coisas mais importantes!
- Documentação da API automática é um bônus muito bem-vindo!
- Lembre-se que o seu código é um espelho da sua qualidade!

## **Desejamos que divirta-se e aproveite ao máximo esse momento de desafio!** 😃😃