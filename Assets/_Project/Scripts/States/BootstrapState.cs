namespace Template._Project.Scripts.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            EnterHub();
        }

        public void Exit() {}

        private void EnterHub()
            => _gameStateMachine.Enter<LoadProgressState>();
    }
}