using UnityEngine;

namespace Source.Modules.Dialogue.Scripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/DialogueOption")]
    public class DialogueOptionSO : ScriptableObject
    {
        [SerializeField, TextArea(1, 5)] private string _optionText;
        [SerializeField] private DialogueSO _nextDialogue;

        public string OptionText => _optionText;
        public DialogueSO NextDialogue => _nextDialogue;
    }
}
