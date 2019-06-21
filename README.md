# API de Patrim�nio - Partner Group
Web API REST para o gerenciamento de patrim�nios de uma empresa.

## Pr�-requisitos
Esta API foi constru�da sobre uma estrutura ASP.NET Core 2.1. Para seu perfeito funcionamento, � necess�ria a configura��o do banco de dados antes de sua primeira execu��o.
1. Preencha a chave ConnectionStrings >> Geral, dentro do arquivo appSettings.json com a ConnectionString correspondente ao banco SQL Server que ser� utilizado para este projeto.
2. Ap�s a configura��o da ConnectionString, � necess�ria a execu��o do script Database.sql, localizado na raiz deste projeto, no banco de dados correspondente para a cria��o das tabelas necess�rias. Uma vez executado tal script, o mesmo n�o recriar� as tabelas caso seja executado novamente. Para recri�-las, as mesmas dever�o ser exclu�das manualmente antes de uma nova execu��o do script.

## Endpoints
GET		marcas						- Obter todas as marcas
GET		marcas/{id}					- Obter uma marca por ID
GET		marcas/{id}/patrim�nios		- Obter todos os patrim�nios de uma marca
POST	marcas						- Inserir uma nova marca
PUT		marcas/{id}					- Alterar os dados de uma marca
DELETE	marcas/{id}					- Excluir uma marca

GET		patrimonios					- Obter todos os patrim�nios
GET		patrimonios/{id}			- Obter um patrim�nio por ID
POST	patrimonios					- Inserir um novo patrim�nio
PUT		patrimonios/{id}			- Alterar os dados de um patrim�nio
DELETE	patrimonios/{id}			- Excluir um patrim�nio

## Observa��o
Considerando que o n�mero de tombo de todo o patrim�nio deve ser �nico e autom�tico, o mesmo foi utilizado como ID/Chave Prim�ria.

## C�digos de Erro
200 - A solicita��o foi realizada com sucesso.
400 - Foi localizado algum problema com os dados enviados para a API.
404 - O registro referenciado na solicita��o n�o foi encontrado na base de dados.
500 - Houve algum erro no servidor durante a execu��o dos processos solicitados.

## Autentica��o
Esta API n�o possui sistema de autentica��o.