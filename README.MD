1. git clone
2. cd CarWash
3. установить пакеты
    """
    dotnet restore
    dotnet add CarWash.Infrastructure package Microsoft.EntityFrameworkCore
    dotnet add CarWash.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add CarWash.Infrastructure package Microsoft.EntityFrameworkCore.Design
    dotnet add CarWash.Presentation package Microsoft.EntityFrameworkCore.Design
    dotnet add CarWash.Presentation package Microsoft.EntityFrameworkCore
    dotnet add CarWash.Presentation package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add CarWash.Presentation package Swashbuckle.AspNetCore
    """
4. dotnet build
5. dotnet ef migrations add InitialCreate --project CarWash.Infrastructure --startup-project CarWash.Presentation
    dotnet ef database update --project CarWash.Infrastructure --startup-project CarWash.Presentation
6. dotnet run --project CarWash.Presentаtion
7. http://localhost:5044/swagger
