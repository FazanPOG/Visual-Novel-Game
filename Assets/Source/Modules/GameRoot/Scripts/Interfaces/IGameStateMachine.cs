namespace Source.Modules.GameRoot.Scripts.Interfaces
{
    public interface IGameStateMachine
    {
        void EnterIn<T>() where T : IGameState;
    }
}
