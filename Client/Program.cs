using Microsoft.Extensions.DependencyInjection;
using Client;

var services = new ServiceCollection();
services.AddSingleton<IRunner, Runner>()
    .BuildServiceProvider()
    .GetService<IRunner>()?.Run(args);
