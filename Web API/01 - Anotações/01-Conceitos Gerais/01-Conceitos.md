API - Aplication Programming Interface:
Conjunto de rotinas e padrões estabelecidos e documentados por uma aplicação para que outras aplicações consigam utilizar suas funcionalidades sem precisar conhecer detalhes da sua implementação.
 - Permitem fazer a integração de sistemas
 - Facilitam o intercâmbio de informações
 - Oferecem maior segurança nos dados
 - Permite fazer controle de acesso
 - São fáceis de implementar e usar

Web API:
É uma API na internet, com um conjunto de serviços expostos via web para realizar a integração da aplicação com diversos tipos de clientes (web, mobile, desktop, etc).
 - Resposta em formato específico como XML, JSON, etc
 - Pode ser acessada usando o protocolo HTTP
 - Tipos de resposta: arquivo texto, imagem, som, operação, banco de dados, etc

REST é um estilo arquitetural sem estado que consiste de um conjunto coordenado de restrições arquiteturais aplicadas a componentes, conectores e elementos de dados dentro de um sistema de hipermídia distribuído.
 Caracteristicas de uma API REST:
  - Tratam cada entidade como um recurso que pode ser acessado por uma interface comum
  - O acesso é baseado no protocolo HTTP (GET, POST, PUT e DELETE)
  
Uma API é Restful quando ela é aderente ao estilo REST:
 - Possuir uma arquitetura cliente-servidor
 - Ser sem estado
 - Ter uma interface uniforme

SOAP é um protocolo baseado em XML, usado para trocar informações entre aplicações no mesmo ou em diferentes sistemas operacionais
 - Todas as mensagem SOAP usam o mesmo formato
 - É independente de protocolo (HTTP, SMTP, etc) e devem retornar XML
 - Um navegador não pode armazenar em cache uma solicitação concluída a uma API SOAP