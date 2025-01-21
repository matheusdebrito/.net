REST é um estilo de arquitetura para a concepção de sistemas distribuídos.
Não é um padrão, não é uma tecnologia, mas é um conjunto de restrições, um conjunto de regras. As principais restrições REST são:
 - Ter um relacionamento cliente/servidor
 - Não possuir monitoração de estado (stateless)
 - Ter uma interface uniforme (URIs, representação, mensagens auto-descritivas, hipermídia(hiperlink, hipertexto))
 - Suportar o cache de dados e respostas
 - Suportar um sistema em camadas

O REST é baseado em 4 pilares:
 - Recurso: É uma abstração sobre um tipo de informação que uma aplicação gerencia que possui identificação única (URI).
  - Representação: É um instantâneo do estado de um recurso em um ponto no tempo. Uma sequência de bytes associado com metadados.
  - Interações sem estado (Stateless): A comunicação entre o cliente e o servidor sempre contém todas as informações necessárias para executar a solicitação.
  - Mensagens: As mensagens devem ser autodescritivas. No HTTP usa-se os verbos, Get, Post, Put e Delete e o header, body, location, media-type.