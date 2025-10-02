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

```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
```


Connections string zitten in appssetting.json:
```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GameStore;Trusted_Connection=True;"
    }
```

```csharp
    // Attributes

    [Required]
    [NotMapped] 
    [MinLength()]
    [MinLength()]
    [Table("tblName", Schema="SchemaName")]
    public class className {}
    [Column("ColumnName", TypeName="Date")]

    
```
