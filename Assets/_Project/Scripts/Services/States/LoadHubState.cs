using System;

namespace _Project.Services.States
{
    public class LoadHubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadHubState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}