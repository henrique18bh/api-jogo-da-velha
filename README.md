# api-jogo-da-velha
Api para um jogo multiplayer de Jogo da Velha


### Executando a API
Em execução na máquina Windows:
```
$ dotnet run .\src\JogoDaVelha\JogoDaVelha.csproj
```

### Arquitetura
Implementação muito simples, seguindo os princípios da arquitetura hexagonal, com todas as camadas isoladas, baseando sempre nas técnicas do SOLID.

### Service
Nesta camada temos a implementação de toda a regra de negócio da aplicação, cada serviço foi desenvolvido com uma unica responsabilidade dentro da aplicação, sempre respeitando o SOLID

### Repository
Camada responsável por persistir os dados, independente da fonte original dos dados. Neste projeto, foi usado salvamento em memoria (MemoryCache) fazendo uso da interface IDistributedCache, assim podemos usar outros tipos de cache na aplicação, caso necessário, Redis é um bom exemplo. 

### Middleware
Neste projeto foi utilizado um Middleware customizado feito para capturar as exceções lançadas na aplicação para facilitar a construção do retorno das APIs. 

### API Documentation
Para documentar as APIs, foi utilizado o Swagger e o Swagger Annotations, com ele é possível deixar explícito toda a documentação da API com seus diferentes status possíveis.
