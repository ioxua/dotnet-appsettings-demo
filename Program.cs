using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
// builder.Services.AddHostedService<Worker>();

// builder.
builder.Configuration.Sources.Clear();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var todoConnString = builder.Configuration.GetConnectionString("Todos");

// inverta essa linha com a próxima pra ver algo legal
builder.Services.AddDbContext<TodoContext>(options => {
    Console.WriteLine($"Configuring DbContext with {todoConnString}");
    options.UseSqlite(todoConnString);
});
builder.Services.AddHostedService<TestTask>();

// var config = builder.Configuration;
// Console.WriteLine(builder.Services);
IHost host = builder.Build();

// DBs may not yet exist
// https://stackoverflow.com/a/55232983/7988516
// https://stackoverflow.com/a/45797475/7988516
using (var serviceScope = host.Services.CreateScope())
{
    TodoContext context = serviceScope.ServiceProvider.GetRequiredService<TodoContext>();
    // var dbCreator = 
    context.Database.Migrate();
    // context.Database.EnsureCreated();
    // context.Database.GetS
    // context.Database.
    // var databaseCreator = context.Database.GetRequiredService<IRelationalDatabaseCreator>();
    // databaseCreator.CreateTables();

}

host.Run();
