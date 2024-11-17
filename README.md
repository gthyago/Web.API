# Web.API

O Web.API disponibiliza uma API RESTful que permite validar se uma senha é válida ou não.

Dúvidas e solicitações relacionadas a integração e API, devem ser enviadas para o e-mail gthyago185@gmail.com.

Recursos disponíveis para acesso via API:
* [**Usuários**](#reference/recursos/usuarios)

# Biblioteca
Integre seu sistema de forma rápida e fácil utilizando nossa [biblioteca para PHP](https://github.com/eGestor/egestor-sdk-php).

## URLs de acesso
O eGestor não possui sandbox (ambiente de homologação). Cada conta do eGestor é isolada das outras (multi-tenant), sugerimos aos desenvolvedores que criem uma conta de testes, e depois utilizem a conta de produção com os dados dos clientes.

Para testar a API, crie uma conta gratuitamente, acesse o sistema e clique no menu configurações. Na aba API você gera o personal_token.

URL homologação/produção (access_token): https://api.egestor.com.br/api/oauth/access_token

URL homologação/produção (ex: contatos): https://api.egestor.com.br/api/v1/contatos


## Métodos
Requisições para a API devem seguir os padrões:
| Método | Descrição |
|---|---|
| `POST` | Utilizado para validar uma nova senha. |


## Respostas

| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `401` | Dados de acesso inválidos.|


#### Dados para envio no POST
| Parâmetro | Descrição |
|---|---|
| `password` | parâmetro com informações da senha a ser validada. |


+ Request (application/json)

    + Body

            {
              "password": "teste01"              
            }

+ Response 200 (application/json)

    + Body

            {
                ""
            }
