# StaffManager

## Descri��o
O StaffManager � uma API em .NET que utiliza DDD (Domain-Driven Design), EntityFramework Core, Padr�o Repository e CQRS com MediatR para gerenciar funcion�rios de maneira eficiente.

## Pr�-requisitos
- .NET Core SDK
- SQL Server

## Configura��o
Atualize a ConnectionString no arquivo appsettings.json com as credenciais do seu banco de dados SQL Server. Em seguida, execute os seguintes comandos para iniciar a aplica��o:

dotnet restore
dotnet ef database update
dotnet run

## Ferramentas e Modelos de Projeto Utilizados
- DDD (Domain-Driven Design): Estrutura��o do projeto baseada em dom�nios.
- EntityFramework Core: ORM para acesso ao banco de dados.
- Padr�o Repository: Abstra��o da camada de acesso a dados.
- CQRS com MediatR: Separa��o das opera��es de leitura e escrita.

## Contribui��o
Contribui��es s�o bem-vindas. Envie um pull request ou abra uma issue para propor mudan�as.