using UnityEngine;

namespace Source.Modules.GameRoot.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private Dialogue.Scripts.DialogueContainer _dialogueContainer;
        
        private void Start()
        {
            _dialogueContainer.Init();
        }
    }
}
