using Source.Modules.Dialogue.Scripts;
using Source.Modules.GameRoot.Scripts.GameStates;
using Source.Modules.GameRoot.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Modules.GameRoot.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        private const string DialogueResourcesPath = "ScriptableObjects/Dialogues";
        
        private IGameStateMachine _gameStateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            InitDialogues();

            _gameStateMachine.EnterIn<BootState>();
        }

        private void InitDialogues()
        {
            DialogueSO[] dialogues = Resources.LoadAll<DialogueSO>(DialogueResourcesPath);
            foreach (DialogueSO dialogue in dialogues)
                dialogue.Init();
        }
    }
}
