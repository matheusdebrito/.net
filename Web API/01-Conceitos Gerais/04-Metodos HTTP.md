Para consumir os recursos de uma Web API RESTful usamos métodos HTTP: GET, POST, PUT e DELETE.

HTTP GET (Read):
    Usado para recuperar informações
    Não altera estados do recurso
    É idempotente(produz o mesmo resultado se repetida)
    Possíveis retornos: 200ok, 404 not found

HTTP POST (Create):
    Usado para criar uma informação
    Altera o estado do recurso
    Não são idempotentes
    Possívies retornos: 201 created, 404 not found

HTTP PUT (Update):
    Usado para atualizar uma informação
    Alteram o estado do recurso
    São idempotentes
    Possíveis retornos: 
        recurso alterado: 200 ok ou 204 no content
        recurso criado: 201 created
    No método PUT a API pode decidir se caso não encontrar o item o método o cria

HTTP DELETE (Delete):
    É usado para deletar uma informação
    Altera o estado do recurso
    É considerao idempotente
    Possíveis retornos: 200ok, 404 not found