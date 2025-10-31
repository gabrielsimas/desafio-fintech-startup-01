# Feedback do Código entregue há 7 anos atrás na íntegra:
#### Achamos sensacional seu interesse em vir trabalhar com a gente, ficamos realmente felizes! Mas decidimos não seguir para as outras etapas do nosso processo. Nossa análise vai além do tecniquês... A gente vê também se a cultura, valores e visão de futuro da pessoa combinam com os nossos e parece que alguma coisa não deu match agora entre nós 😥
#### Como a transparência é um dos nossos pilares, a ideia é te passar o que identificamos nesse período, para você ter em mente:

## **O que você mandou bem**
> ### *Possui conhecimento da linguagem, sabe utilizar lambda e conhece os conceitos básicos de OO.*

> ### ***Ponto positivo** por tentar utilizar interfaces*.
> ### Ele se esforçou pra dar bons nomes mas fez coisas tipo isso*:
```csharp
private float CalculaParticipacaoDoFuncionario(Participacao participante, float salarioMinimoNacional)
{
    float sb = participante.SalarioBruto;
    int pta = participante.Pesos.RetornaPesoTempoAdmissao();
    int pfs = participante.Pesos.RetornaPesoFaixaSalarial();
    int paa = participante.Pesos.RetornaPesoAreaDeAtuacao();
    float _valorParticipacao = (((sb * pta) + (sb * paa)) / (pfs)) * 12;
    return _valorParticipacao;
}
```
## **O quê (sic) precisa aprender/evoluir**:
> ### O desafio não foi completo, ou seja, não foi possivel utilizar e pra um problema desse tipo, acho ruim não terminar.
> ### Tentou mostrar que conhece DDD*** iniciando a criação das camadas mas acabou ficando muito código pra pouca funcionalidade e a maioria das camadas se quer tem código.
> ### Faltou foco no problema que desejava resolver de maneira simples e direta, mostrando um foco maior em tudo em torno do problema menos no problema.*
> ### Pastas e nomes despadronizados em relação a linguagem e convenções do C#.*
> ### Faltou um readme básico explicando as decisões e a escolha do modelo e o projeto, assim como instruções de execução.
> ### Tem muito código que não possui ligação com nenhuma funcionalidade, dá a impressão que foi meramente colocado ali sem qualquer relação com o problema.
> ### Parece não conhecer sobre boas práticas, SOLID e Design Patterns.
> ### Em relação a testes unitários, sabe muito pouco sobre os conceitos.
> ### Criou uma pasta TDD dentro do projeto de testes usou nomes pobres.
> ### fez testes que eram praticamente testar a criação de uma classe.