using Microsoft.Extensions.Hosting;

public class TestTask : BackgroundService
{
    private readonly TodoContext _todoContext;

    public TestTask(TodoContext todoContext) => _todoContext = todoContext;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _todoContext.Add(new Todo("buy groceries", false));
        await Task.Delay(1000, stoppingToken);
        await _todoContext.SaveChangesAsync();
    }
}