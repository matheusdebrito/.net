# Escopo
Criar uma Web API para um catálogo de produtos/categorias que pode atender uma rede de lojas ou supermercados
 - Criar um serviço RESTful que permita que aplicativos clientes gerenciem o catálogo de produtos e categorias.
 - Expor endpoints para criar, ler, editar e excluir produtos e também consultar produtos e um produto específico.
 - Export endpoints para criar, ler, editar e excluir categorias e também consultar categorias, uma categoria específica e os produtos de uma categoria

 - Para categorias, precisamos armazenar: o nome e o caminho da imagem
 - Para produtos , precisamos armazenar: nome, descrição, valor unitário, caminho da imagem, estoque data do cadastro e categoria.

# Definição dos recursos, dos endpoints e do mapeamento
Endpoint para produtos:
 - GET /v1/api/produtos
 - GET /vi/api/produtos/1
 - POST /v1/api/produtos
 - PUT /v1/api/produtos/1
 - DELETE /v1/api/produtos/1

Endpoint para categorias:
 - GET /v1/api/categorias
 - GET /vi/api/categorias/1
 - GET /vi/api/categorias/1/produtos
 - POST /v1/api/categorias
 - PUT /v1/api/categorias/1
 - DELETE /v1/api/categorias/1

# Implementar a segurança
Permitir o acesso às APIs somente a usuários autenticados.
Definir uma política de autorização de acesso aos usuários.

Criar um servico RESTful que permita gerencias os usuários.

Expor os endpoints para criar, ler, editar e excluir usuários e também consultar usuários e um usuário específico.

Para os usuários podemos armazenar: nome, email, senha

Endpoint para usuários:
 - GET /v1/api/usuarios
 - GET /vi/api/usuarios/1
 - POST /v1/api/usuarios
 - PUT /v1/api/usuarios/1
 - DELETE /v1/api/usuarios/1

# Nomenclaturas

Nome do projeto: APICatalogo
Nome dos controllers (no plural): ProtudosController, CategoriasController, UsuariosController
Nome das Actions: Acesso feito via verbos http: Get, Put, Post e Delete
 - Usar atributos: HttpGet, HttpPost, HttpPut e HttpDelete
Uma instância de um recurso (no plural): /v1/api/produtos, /v1/api/categorias e /v1/api/usuarios
Usar substantivos e não verbos: /v1/api/produtos e não /v1/api/GetTodosProdutos