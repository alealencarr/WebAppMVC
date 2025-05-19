# Controle de Contatos

Este projeto é um sistema de controle de contatos desenvolvido em .NET Core, utilizando Blazor, Entity Framework Core e padrão MVC. O objetivo é gerenciar contatos de forma eficiente, com funcionalidades de login, envio de emails, autenticação, controle de perfis e muito mais.

## Tecnologias Utilizadas

* .NET Core
* Blazor
* Entity Framework Core
* Padrão MVC
* Injeção de Dependência
* JavaScript Vanilla
* jQuery
* Bootstrap
* HTML/CSS
* AJAX
* Views Parciais
* Modais
* Async Components

## Funcionalidades

* Tela de Login com autenticação 
* Criptografia de senha e envio por email a nova senha
* Cadastro, Edição e Exclusão de Contatos
* Cadastro, Edição e Exclusão de Usuarios, somente para usuarios com perfis de acesso a esta funcionalidade
* Alteração de Senha
* Filtros para definir acesso às rotas por perfil de usuário
* Modal genérico para confirmação de ações
* Validações e notificações em tempo real
* Uso de AJAX para atualização dinâmica dos componentes

## Estrutura do Projeto

* Controllers: Controladores que gerenciam as requisições e retornam as views.
* Models: Entidades e view models utilizadas no sistema.
* Views: Interfaces visuais organizadas por módulo (Login, Contatos, etc.).
* Components: Componentes reutilizáveis implementados em Blazor.
* Repositorios: Lógica de negócios, envio de emails e criptografia de senhas.

## Execução do Projeto

1. Clone o repositório:

   ```bash
   git clone <[URL do repositório](https://github.com/alealencarr/WebAppMVC.git)>
   ```

2. Configure as user-secrets:

   ```bash
   dotnet user-secrets set "SMTP:UserName" "seu_email@example.com"
   dotnet user-secrets set "SMTP:Senha" "sua_senha"
   dotnet user-secrets set "SMTP:Host" "smtp-mail.outlook.com"
   dotnet user-secrets set "SMTP:Porta" "587"
   ```

3. Crie o banco de dados (Defina a connection através de User-Secrets):

   ```bash
   dotnet ef database update
   ```

4. Execute o projeto:

   ```bash
   dotnet run
   ```
 
## Considerações

- As senhas são criptografadas antes de serem armazenadas no banco.
- O envio de emails utiliza as configurações definidas nos user-secrets.
- Os filtros garantem que apenas usuários autenticados com permissão de acesso possam acessar determinadas rotas.

Para mais detalhes, consulte o código fonte ou entre em contato comigo através do e-mail: ale.alencarr@outlook.com.br

```
