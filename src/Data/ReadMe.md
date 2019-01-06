

--scaffold Entity Framework core mysql pamelo
dotnet ef dbcontext scaffold "Server=localhost;UserId=root;Password=erda19;port=3308;Database=salesdb" "Pomelo.EntityFrameworkCore.MySql" -c MyDbContext -o Models