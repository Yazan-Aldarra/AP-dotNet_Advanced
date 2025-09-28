# ASP.NET Core
```csharp
    [FromQuery]
    [FromHedear]
    [FromBody]
```
Voor file structure wordt er 3 benamingen gebruikt voor de classe van entiteiten of dinges van onze project.
-   Models
-   Entities
-   Domain

## EF Core 
EF core is een ORM object relational Mapper

### Packages namen
```bash
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# dit package is voor ef commandos zoals `dotnet ef migrations add`
 dotnet add package Microsoft.EntityFrameworkCore.Tools

```
Connections string zitten in appssetting.json:
```json
    "ConnectionString": ""
```

