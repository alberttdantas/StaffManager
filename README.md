# StaffManager

## Descrição
O StaffManager é uma API em .NET que utiliza DDD (Domain-Driven Design), EntityFramework Core, Padrão Repository e CQRS com MediatR para gerenciar funcionários de maneira eficiente.

## Pré-requisitos
- .NET Core SDK
- SQL Server

## Configuração
Atualize a ConnectionString no arquivo appsettings.json com as credenciais do seu banco de dados SQL Server. Em seguida, execute os seguintes comandos para iniciar a aplicação:

dotnet restore
dotnet ef database update
dotnet run

## Ferramentas e Modelos de Projeto Utilizados
- DDD (Domain-Driven Design): Estruturação do projeto baseada em domínios.
- EntityFramework Core: ORM para acesso ao banco de dados.
- Padrão Repository: Abstração da camada de acesso a dados.
- CQRS com MediatR: Separação das operações de leitura e escrita.

## Contribuição
Contribuições são bem-vindas. Envie um pull request ou abra uma issue para propor mudanças.