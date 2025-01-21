Uma requisição HTTP é dividida em 3 partes
 - 1 Request line: Método HTTP + URI + protocolo HTTP
    GET /api/livros HTTP/1.1
    POST /api/livros HTTP/1.1

 - 2 Headers: Metadados que se enviam na requisição como informação
    Host: Microsoft.com        Accept: text/*
    Cache-Control: no-cache    Accept-Language: pt, br 

 - 3 Body (opcional): Informação adicional enviada ao servidor
    Dados de texto

Uma resposta HTTP também é divididad em 3 partes
 - 1 Status line: Indica o status da requisição (Código Status HTTP)
    HTTP/1.1 200 ok
    HTTP/1.1 404 Not Found

 - 2 Headers: Metadados que são enviados na resposta
    Content-type: text-plain
    Content-length: 80

 - 3 Body (opcional): Dados de texto
    Dados de texto
    Dados JSON
    