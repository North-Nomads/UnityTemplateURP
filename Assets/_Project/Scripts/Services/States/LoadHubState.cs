using System;
using _Project.UI.Services.Windows;
using _Project.UI.Views;

namespace _Project.Services.States
{
    public class LoadHubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IWindowContainer _windowContainer;

        public LoadHubState(GameStateMachine gameStateMachine, IWindowContainer windowContainer)
        {
            _gameStateMachine = gameStateMachine;
            _windowContainer = windowContainer;
        }

        public void Exit()
        {
            // _windowContainer.Open<UserMoneyView>();
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}