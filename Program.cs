var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=blog.db";

// 2. Registra o BlogDbContext no sistema de injeção de dependência da aplicação,
//    configurando-o para usar o SQLite com a string de conexão que definimos.
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlite(connectionString));

// --- FIM DA ADIÇÃO ---
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseHttpsRedirection();


app.Run();