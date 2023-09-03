namespace Client;

public class Runner : IRunner
{
    private readonly IGameControl _gameControl;

    public Runner(IGameControl gameControl) => _gameControl = gameControl;

    public void Run(string[] args)
    {
        _gameControl.Start();
    }
}
