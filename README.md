# Chat
Group chat app using ASP.NET Blazor.

## Setup
Create database migrations:
```
$ cd chat
$ dotnet ef migrations add InitialCreate --project src/Chat.Data --startup-project src/Chat.Web --context ChatDbContext
```

## Deploying
1. Run all services under `docker-compose.yml`
```
$ docker compose up -d
```
1. Visit `http://localhost` and verify page loads
2. (Optional) place HTTPS cert under `~/.aspnet/https` to enable HTTPS (see [link](https://docs.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-6.0))
