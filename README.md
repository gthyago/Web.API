# Web.API

O Web.API disponibiliza uma API RESTful que permite validar se uma senha é válida ou não.

Dúvidas e solicitações relacionadas a integração e API, devem ser enviadas para o e-mail gthyago185@gmail.com.

Recursos disponíveis para acesso via API:
* [**Usuários**](#reference/recursos/usuarios)

## Tecnologia
| Target framework | Versão |
|---|---|
| `.NET` | 5.0 |
| `XUnit` | 2.4.1 |

## URLs de acesso
O Web.API não possui sandbox (ambiente de homologação). Sugerimos aos desenvolvedores que clone o repositório e execute localmente.

Para testar a API:
1. Clonar o projeto.
2. Abra o Visual Studio.
3. Executar rebuild da solution.
4. Clique Start Without Debugging.

URL repositório: https://github.com/gthyago/Web.API

URL Web.API: https://localhost:44309/swagger/index.html

## Comandos
Como clonar o projeto:
| Comando | Descrição |
|---|---|
| `git clone https://github.com/gthyago/Web.API.git` | Utilizado para clonar o projeto. |

## Métodos
Requisições para a API devem seguir os padrões:
| Método | Descrição |
|---|---|
| `POST` | Utilizado para validar uma nova senha. |

## Respostas
| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `401` | A combinação da senha não está de acordo com os critérios solicitados!|


#### Dados para envio no POST
| Parâmetro | Descrição |
|---|---|
| `password` | Parâmetro com informações da senha a ser validada. |


+ Request (application/json)

    + Body

            {
              "password": "String-111"              
            }

+ Response 200 (application/json)

    + Body

            {
			  "message": "Senha validada com sucesso!",
  			  "success": true
			}
			
+ Request (application/json)

    + Body

            {
              "password": "string"              
            }

+ Response 401 (application/json)

    + Body

            {
			  "message": "A combinação da senha não está de acordo com os critérios solicitados!",
			  "success": false
			}
