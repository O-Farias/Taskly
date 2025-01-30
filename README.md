# Taskly
Taskly é uma API REST para gerenciamento de tarefas, permitindo criar, editar, excluir e marcar tarefas como concluídas. Construída com C# e .NET, utiliza Entity Framework para persistência e um design modular para escalabilidade. Perfeito para organizar atividades do dia a dia de forma simples e eficiente. 


## Features

- CRUD completo de tarefas
- Marcação de tarefas como concluídas
- Filtragem por status (concluídas/pendentes)
- Persistência em banco de dados SQLite
- API RESTful seguindo boas práticas
- Documentação via Swagger

## Tecnologias Utilizadas

- .NET 8.0
- Entity Framework Core
- SQLite
- Swagger/OpenAPI

## Pré-requisitos

- .NET SDK 8.0 ou superior
- Visual Studio 2022, VS Code ou similar
- Postman ou similar (para testes)

## Instalação

1. Clone o repositório:
```bash
git clone https://github.com/O-Farias/Taskly.git
```

2. Navegue até a pasta do projeto:
```bash
cd Taskly
```

3. Restaure as dependências:
```bash
dotnet restore
```

4. Execute as migrações:
```bash
dotnet ef database update
```

5. Inicie o projeto:
```bash
dotnet run
```

## Estrutura do Projeto

```
Taskly/
├── Controllers/
│   └── TaskController.cs
├── Models/
│   └── TodoTask.cs
├── Data/
│   └── TasklyContext.cs
├── Migrations/
└── Properties/
```

## Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | /api/tasks | Lista todas as tarefas |
| GET | /api/tasks/{id} | Obtém uma tarefa específica |
| POST | /api/tasks | Cria uma nova tarefa |
| PUT | /api/tasks/{id} | Atualiza uma tarefa |
| DELETE | /api/tasks/{id} | Remove uma tarefa |
| PATCH | /api/tasks/{id}/complete | Marca tarefa como concluída |

## Exemplos de Uso

### Criar uma Tarefa
```http
POST /api/tasks
Content-Type: application/json

{
    "title": "Estudar C#",
    "description": "Aprender mais sobre Entity Framework"
}
```

### Marcar como Concluída
```http
PATCH /api/tasks/1/complete
```

## Contribuindo

1. Faça um Fork do projeto
2. Crie sua Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

