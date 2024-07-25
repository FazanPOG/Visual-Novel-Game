using System.Collections.Generic;
using Source.Static.Extensions.Scripts;
using UnityEngine;

namespace Source.Modules.Dialogue.Scripts
{
    [CreateAssetMenu(menuName = "ScriptableObject/Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        [SerializeField, TextArea(1, 5)] private List<string> _dialogueTexts;
        [SerializeField] private List<DialogueOptionSO> _options;

        private Queue<string> _dialogueQueue;

        public IReadOnlyList<DialogueOptionSO> Options => _options.AsReadOnly();

        public void Init()
        {
            _dialogueQueue = _dialogueTexts.ToQueue();
        }

        public Queue<string> GetDialogueQueueClone()
        {
            return new Queue<string>(_dialogueQueue);
        }
    }
}
