using System;
using System.Collections.Generic;
using Source.Modules.Factories.Scripts.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Source.Modules.Dialogue.Scripts
{
    [RequireComponent(typeof(DialogueTextHandler))]
    public class DialogueContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;

        private IOptionButtonFabric _optionButtonFabric;
        
        private DialogueTextHandler _textHandler;
        private DialogueSO _currentDialogue;
        private Queue<string> _currentDialogueTexts;

        private void Awake() => _textHandler = GetComponent<DialogueTextHandler>();

        private void OnEnable()
        {
            _textHandler.OnNeedShowNextText += ShowNextText;
        }

        [Inject]
        private void Construct(IOptionButtonFabric optionButtonFabric)
        {
            _optionButtonFabric = optionButtonFabric;
        }
        
        public void Init()
        {
            _textHandler.Init(_textComponent);
        }
        
        public void StartDialogue(DialogueSO dialogue)
        {
            Debug.Log("Start dialogue");
            
            _optionButtonFabric.DestroyAllOptions();
            _currentDialogue = dialogue;
            _currentDialogueTexts = _currentDialogue.GetDialogueQueueClone();
            ShowNextText();
        }

        private void ShowNextText()
        {
            if (_currentDialogueTexts.Count == 1)
                CreateDialogueOptions(_currentDialogue.Options);
            
            _textHandler.ShowText(_currentDialogueTexts.Dequeue());
        }

        private void CreateDialogueOptions(IReadOnlyList<DialogueOptionSO> options)
        {
            for (int i = 0; i < options.Count; i++)
                _optionButtonFabric.Create(options[i]);
        }
        
        private void OnDisable()
        {
            _textHandler.OnNeedShowNextText -= ShowNextText;   
        }
    }
}
