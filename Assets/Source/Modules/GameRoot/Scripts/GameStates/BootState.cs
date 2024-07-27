using Source.Modules.Dialogue.Scripts;
using Source.Modules.GameRoot.Scripts.Interfaces;

namespace Source.Modules.GameRoot.Scripts.GameStates
{
    public class BootState : IGameState
    {
        private readonly DialogueContainer _dialogueContainer;

        public BootState(DialogueContainer dialogueContainer)
        {
            _dialogueContainer = dialogueContainer;
        }
        
        public void Enter()
        {
            _dialogueContainer.Init();
        }

        public void Exit()
        {
        
        }
    }
}
