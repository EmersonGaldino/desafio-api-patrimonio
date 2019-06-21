# API de Patrimônio - Partner Group
Web API REST para o gerenciamento de patrimônios de uma empresa.

## Pré-requisitos
Esta API foi construída sobre uma estrutura ASP.NET Core 2.1. Para seu perfeito funcionamento, é necessária a configuração do banco de dados antes de sua primeira execução.
1. Preencha a chave ConnectionStrings >> Geral, dentro do arquivo appSettings.json com a ConnectionString correspondente ao banco SQL Server que será utilizado para este projeto.
2. Após a configuração da ConnectionString, é necessária a execução do script Database.sql, localizado na raiz deste projeto, no banco de dados correspondente para a criação das tabelas necessárias. Uma vez executado tal script, o mesmo não recriará as tabelas caso seja executado novamente. Para recriá-las, as mesmas deverão ser excluídas manualmente antes de uma nova execução do script.

## Endpoints
1.  GET		marcas						- Obter todas as marcas
2.  GET		marcas/{id}					- Obter uma marca por ID
3.  GET		marcas/{id}/patrimônios		- Obter todos os patrimônios de uma marca
4.  POST	marcas						- Inserir uma nova marca
5.  PUT		marcas/{id}					- Alterar os dados de uma marca
6.  DELETE	marcas/{id}					- Excluir uma marca

7.  GET		patrimonios					- Obter todos os patrimônios
8.  GET		patrimonios/{id}			- Obter um patrimônio por ID
9.  POST	patrimonios					- Inserir um novo patrimônio
10. PUT		patrimonios/{id}			- Alterar os dados de um patrimônio
11. DELETE	patrimonios/{id}			- Excluir um patrimônio

## Observação
Considerando que o número de tombo de todo o patrimônio deve ser único e automático, o mesmo foi utilizado como ID/Chave Primária.

## Códigos de Erro
1. 200 - A solicitação foi realizada com sucesso.
2. 400 - Foi localizado algum problema com os dados enviados para a API.
3. 404 - O registro referenciado na solicitação não foi encontrado na base de dados.
4. 500 - Houve algum erro no servidor durante a execução dos processos solicitados.

## Autenticação
Esta API não possui sistema de autenticação.