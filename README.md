# API de Patrimônio - Partner Group
Web API REST para o gerenciamento de patrimônios de uma empresa.

## Pré-requisitos
Esta API foi construída sobre uma estrutura ASP.NET Core 2.1. Para seu perfeito funcionamento, é necessária a configuração do banco de dados antes de sua primeira execução.
1. Preencha a chave ConnectionStrings >> Geral, dentro do arquivo appSettings.json com a ConnectionString correspondente ao banco SQL Server que será utilizado para este projeto.
2. Após a configuração da ConnectionString, é necessária a execução do script Database.sql, localizado na raiz deste projeto, no banco de dados correspondente para a criação das tabelas necessárias. Uma vez executado tal script, o mesmo não recriará as tabelas caso seja executado novamente. Para recriá-las, as mesmas deverão ser excluídas manualmente antes de uma nova execução do script.

## Endpoints
GET		marcas						- Obter todas as marcas
GET		marcas/{id}					- Obter uma marca por ID
GET		marcas/{id}/patrimônios		- Obter todos os patrimônios de uma marca
POST	marcas						- Inserir uma nova marca
PUT		marcas/{id}					- Alterar os dados de uma marca
DELETE	marcas/{id}					- Excluir uma marca

GET		patrimonios					- Obter todos os patrimônios
GET		patrimonios/{id}			- Obter um patrimônio por ID
POST	patrimonios					- Inserir um novo patrimônio
PUT		patrimonios/{id}			- Alterar os dados de um patrimônio
DELETE	patrimonios/{id}			- Excluir um patrimônio

## Observação
Considerando que o número de tombo de todo o patrimônio deve ser único e automático, o mesmo foi utilizado como ID/Chave Primária.

## Códigos de Erro
200 - A solicitação foi realizada com sucesso.
400 - Foi localizado algum problema com os dados enviados para a API.
404 - O registro referenciado na solicitação não foi encontrado na base de dados.
500 - Houve algum erro no servidor durante a execução dos processos solicitados.

## Autenticação
Esta API não possui sistema de autenticação.