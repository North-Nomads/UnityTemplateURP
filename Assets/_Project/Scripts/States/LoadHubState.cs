namespace Template._Project.Scripts.States
{
    public class LoadHubState: IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadHubState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }
    }
}