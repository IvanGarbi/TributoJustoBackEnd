# TributoJustoBackEnd

Teste realizado para a Tributo Justo.

# API REST - Documentação Swagger
CRUD de Filmes, Livros e Favoritos. 
<br>
Consulta de livros através de API terceiras.
<br>
Consulta de filmes através de API terceiras.
<br>
Exclusão de favorito.
<br>
Consulta de favoritos do usuário.
<br>
Testes de Unidade com xUnit.NET

# Tecnologias
* .NET 6
* EntityFramework
* FluentValidation
* SQL Server
* AutoMapper
* xUnit.NET


# Funcionamento
Primeiramente é necessário rodar a migration contida no projeto Data.
Após criado o banco de dados, é necessário inserir as duas chaves de consumo das API terceiras, da Google e da OmdbApi. As chaves devem ser inseridas dentro das Controllers no projeto API.
