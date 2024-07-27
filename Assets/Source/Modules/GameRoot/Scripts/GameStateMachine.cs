using System;
using System.Collections.Generic;
using Source.Modules.Dialogue.Scripts;
using Source.Modules.GameRoot.Scripts.GameStates;
using Source.Modules.GameRoot.Scripts.Interfaces;
using Zenject;

namespace Source.Modules.GameRoot.Scripts
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IGameState> _states;
        private IGameState _currentGameState;

        [Inject]
        public GameStateMachine(DialogueContainer dialogueContainer)
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(BootState)] = new BootState(dialogueContainer),
                [typeof(GameState)] = new GameState(),
                [typeof(EndGameState)] = new EndGameState(),
            };
        }

        public void EnterIn<T>() where T : IGameState
        {
            if (_states.TryGetValue(typeof(T), out IGameState gameState) == false) return;

            _currentGameState?.Exit();

            _currentGameState = gameState;
            _currentGameState.Enter();
        }
    }
}
