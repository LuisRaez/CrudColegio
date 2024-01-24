# CrudColegio

Crud de un colegio para alumnos, docentes y aulas
Se utilizó .net 8 para la api de ASP.NET Core 
Se utilizó EntityFramework en DataBaseFirst para obtener la info de la db

EN POWERSHELL
dotnet ef dbcontext scaffold "Server=DESKTOP-MU9FF4Q;DataBase=Escuela;Trusted_Connection=True;Encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -o Models

EN Consola de Administrador de Paquetes
Scaffold-DbContext "Server=DESKTOP-MU9FF4Q;DataBase=Escuela;Trusted_Connection=True;Encrypt=false;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Se cambió el modo de conexion del dbcontext por otro en el program.cs
builder.Services.AddDbContext<EscuelaContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});
