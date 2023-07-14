using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

public class TodoContext : DbContext
{
    // private readonly IConfiguration _config;
    public DbSet<Todo> Todos { get; set; }
    public string DbPath { get; }

    public TodoContext(
        IConfiguration config,
        DbContextOptions<TodoContext> options,
        IHostApplicationLifetime appLifetime) : base(options)
    {
        // _config = config;
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "todo.db");
    }

    // da pra configurar aqui, mas da pra fazer no Program.cs
    // https://stackoverflow.com/questions/69472240/asp-net-6-identity-sqlite-services-adddbcontext-how
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     {
    //         // options.UseSqlite($"Data Source={DbPath}");
    //         var configuration = new ConfigurationBuilder()
    //             .SetBasePath(Directory.GetCurrentDirectory())
    //             .AddJsonFile("appsettings.json")
    //             .Build();

    //         var appDb = configuration.GetConnectionString("Todos");
    //         options.UseSqlite($"Data Source={appDb}");
    //     }
}

public class Todo
{
    public long Id { get; set; }
    public string Desc { get; set; }
    public bool Done { get; set; }

    public Todo(string desc, bool done)
    {
        Desc=desc;
        Done=done;
    }
}
