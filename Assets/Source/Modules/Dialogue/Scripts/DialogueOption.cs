using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Modules.Dialogue.Scripts
{
    public class DialogueOption : MonoBehaviour
    {
        [SerializeField] private Button _optionButton;
        [SerializeField] private TextMeshProUGUI _optionText;

        private DialogueOptionSO _dialogueOptionSo;
        private DialogueContainer _dialogueContainer;

        public DialogueSO NextDialogue => _dialogueOptionSo.NextDialogue;
        
        public void Init(DialogueOptionSO dialogueOptionSo, DialogueContainer dialogueContainer)
        {
            _dialogueOptionSo = dialogueOptionSo;
            _dialogueContainer = dialogueContainer;
            
            _optionText.text = _dialogueOptionSo.OptionText;
            _optionButton.onClick.AddListener(StartNextDialogue);
        }

        private void StartNextDialogue() => _dialogueContainer.StartDialogue(_dialogueOptionSo.NextDialogue);
        
        private void OnDisable()
        {
            _optionButton.onClick.RemoveListener(StartNextDialogue);
        }
    }
}
