using Source.Modules.Dialogue.Scripts;
using UnityEngine;

namespace Source.Modules.GameRoot.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        private const string DialogueResourcesPath = "ScriptableObjects/Dialogues";
        
        [SerializeField] private DialogueContainer _dialogueContainer;
        [SerializeField] private DialogueSO _dialogue;
        
        private void Start()
        {
            InitDialogues();
            
            _dialogueContainer.Init();
            _dialogueContainer.StartDialogue(_dialogue);
        }

        private void InitDialogues()
        {
            DialogueSO[] dialogues = Resources.LoadAll<DialogueSO>(DialogueResourcesPath);
            foreach (DialogueSO dialogue in dialogues)
                dialogue.Init();
        }
    }
}
