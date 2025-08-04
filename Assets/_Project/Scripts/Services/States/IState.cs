namespace _Project.Services.States
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payload);
    }
}