

--scaffold Entity Framework core mysql pamelo
dotnet ef dbcontext scaffold "Server=localhost;User Id=root;Password=1234;Database=MyTestDB" "Pomelo.EntityFrameworkCore.MySql" -c MyDbContext -o Models