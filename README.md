# GX2.DigitalLibrary
## Desafio Back-End .Net Pleno

***
As frameworks utilizadas para este projeto: `.Net 5, AutoMapper, EntityFramework Core, Identity, JwtBearer`

Aqui entenderá o funcionamento dos controllers para realização de testes integrados.

Ao iniciar o software pela primeira vez, irá adicionar usuário **gcm10000** com role "Admin" (veja mais [aqui](https://github.com/gcm10000/GX2.DigitalLibrary/blob/1516910780c824bad78d8dc2bfc57ab27a3827a8/GX2.DigitalLibrary.Helper/GenericHelper.cs#L13)) então não há problemas em fazer alteração no método [RegisterAsync](https://github.com/gcm10000/GX2.DigitalLibrary/blob/1516910780c824bad78d8dc2bfc57ab27a3827a8/GX2.DigitalLibrary/Controllers/API/AccountController.cs#L29).

## TokenController
Para obter o token JWT necessário para que utilize a aplicação, basta acessar a rota com verbo POST `/api/token/v1/access-token`
### Exemplo:
```
{
    "username": "gcm10000",
    "password": "SenhaSecreta#2021"
}
```
Sendo validado com sucesso, irá retornar JSON com os seguintes campos e tipos: `access_token: string, token_type: string, expires_in: int`.


**Lembre-se, para todos os métodos abaixo será necessário a utilização do token bearer obtido.**


## AccountController

Este controller é exclusivo do administrador e tem três métodos a serem usados.
### 1. RegisterAsync([FromBody] RegisterViewModel register):
Este método serve para adicionar um novo usuário, podendo ser User (comum) ou Admin (administrador).

   Rota com verbo POST: `/api/account/register`
### Exemplo:
```
{
    "username": "g11000",
    "name": "Gabriel Machado",
    "password": "SenhaSecreta#3030",
    "email": "gabrielmachado@machado.com",
    "role": "User"
}
```

Os requisitos da senha durante o registro do usuário encontram-se padrão. [Saiba mais](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-6.0#:~:text=TABLE%203-,Property,true,-Sign%2Din).

### 2. UpdateAsync([FromBody] RegisterViewModel model):
Este método serve para atualizar um usuário.

   Rota com verbo POST: `/api/account/update`

```
{
    "username": "g11000",
    "name": "Gabriel Chagas Machado",
    "password": "SenhaSecreta#5050",
    "email": "gabrielmachado@gmail.com",
    "role": "User"
}
```

### 3. DeleteAsync(string id):
Este método serve para atualizar um usuário.

   Rota com verbo DELETE: `/api/account/delete/{id}`

   Não há necessidade corpo na requisição.


## AuthorController

Este controller há métodos de CRUD, onde o usuário comum e administrador pode visualizar autor(es). Administrador também tem a possibilidade de adicionar, atualizar e remover autores caso seja conveniente.

### 1. Index():
   Este método serve para listar todos os autores.

   Rota com verbo GET: `/api/author/Index`

   Não há necessidade corpo na requisição.

### 2. Find(int index):
   Este método serve para exibir um autor em questão.

   Rota com verbo GET: `/api/author/{id}`

   Não há necessidade corpo na requisição.

### 3. Add([FromBody] AuthorViewModel author):
   Este método serve para adicionar um novo autor ao banco de dados.

   Rota com verbo POST: `/api/author/Add`

### Exemplo:
```
{
    "name": "Leonardo da Vinci"
}
```

### 4. Update([FromBody] AuthorViewModel author):
   Este método serve para atualizar um autor ao banco de dados.

   Rota com verbo POST: `/api/author/Update`

### Exemplo:
```
{
    "author_id": 1,
    "name": "Leonardo da 20"
}
```

O campo **author_id** é obrigatório para a alteração do autor em questão.

### 5. Delete(int id):
   Este método serve para apagar um autor do banco de dados.

   Rota com verbo DELETE: `/api/author/Delete/{id}`

   Não há necessidade corpo na requisição.


## BookController

Este controller há métodos de CRUD, onde o usuário comum e administrador pode visualizar livro(s) e filtrar por categoria. Administrador também tem a possibilidade de adicionar, atualizar e remover livros caso seja conveniente.

### 1. Index():
   Este método serve para listar todos os livros.

   Rota com verbo GET: `/api/book/Index`

   Não há necessidade corpo na requisição.

### 2. Find(int index):
   Este método serve para exibir um livro em questão.

   Rota com verbo GET: `/api/book/{id}`

   Não há necessidade corpo na requisição.

### 3. FindByCategory(string category):
   Este método serve para exibir livros filtrados por categoria.

   Rota com verbo GET: `/api/book/{category}`

   Não há necessidade corpo na requisição.


### 4. Add([FromBody] BookViewModel book):
   Este método serve para adicionar um novo livro ao banco de dados.

   Rota com verbo POST: `/api/book/Add`

### Exemplo:
```
{
    "name": "Leonardo da Vinci"
}
```

### 5. Update([FromBody] BookViewModel book):
   Este método serve para atualizar um livro ao banco de dados.

   Rota com verbo POST: `/api/book/Update`

### Exemplo:
```
{
    "book_id": 1,
    "name": "Leonardo da 20"
}
```

O campo **book_id** é obrigatório para a alteração do livro em questão.

### 6. Delete(int id):
   Este método serve para apagar um livro do banco de dados.

   Rota com verbo DELETE: `/api/book/Delete/{id}`

   Não há necessidade corpo na requisição.


## MovementBookController
Este controller é feito somente para a utilização do usuário há dois métodos chamados Reserve e Return.

O username é resgatado na sua claim, veja o código [aqui](https://github.com/gcm10000/GX2.DigitalLibrary/blob/1516910780c824bad78d8dc2bfc57ab27a3827a8/GX2.DigitalLibrary.Services/Services/MovementBookService.cs#L44).

### 1. Reserve([FromBody] BookViewModel book)
   Este método serve para reservar o livro decrementando a quantidade e atrelando ao usuário que efetuou a reserva.

   Rota com verbo POST: `/api/movementBook/reserve`
### Exemplo
```
{
    "book_id": 1
}
```
### 2. Return([FromBody] BookViewModel book)
   Este método serve para retornar o livro à biblioteca, incrementando a quantidade e desatrelando o usuário que efetuou a reserva.

   Rota com verbo POST: `/api/movementBook/return`
### Exemplo
```
{
    "book_id": 1
}
```
