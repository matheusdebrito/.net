# Tratamento de erros global usando middleware
Podemos usar o middleware UseExceptionHandler para realizar o tratamento de exceções. Ele pode ser usado para manipular exceções globalmente e obter todos os detalhes do objeto Exception (rastreamento de pilha, exceção interna, mensagens, etc.)

Vamos configurar um middleware de tratamento de exceções UseExceptionHandler para capturar exceções não tratadas, definir uma resposta HTTP com um código de status 500, obter os detalhes da execução no formato JSON e enviar a resposta de volta ao cliente.

# Roteiro
- Criar uma entidade chamada ErrorDetails que é uma classe usada para representar os detalhes dos erros
- Criar um método de extenção ConfigureExceptionHandler para IApplicationBuilder
- Usar o middleware UseExceptionHandler e configurar o tratamento de erros
- Habilitar o uso do método de extenção ConfigureExceptionHandler na classe Program (app.ConfigureExceptionHandler())
- Testar a implementação no Swagger e no Postman.