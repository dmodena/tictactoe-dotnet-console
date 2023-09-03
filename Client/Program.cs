using Microsoft.Extensions.DependencyInjection;
using Client;
using Game.Boards;
using Game.Players;

var services = new ServiceCollection();
ConfigureServices(services);
services.AddSingleton<IRunner, Runner>()
    .BuildServiceProvider()
    .GetService<IRunner>()?.Run(args);

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IBoard, Board>();
    services.AddTransient<IReversingBoard, ReversingBoard>();
    services.AddTransient<IPlayer, PredictablePlayer>();
    services.AddSingleton<IGameControl, GameControl>();
}
