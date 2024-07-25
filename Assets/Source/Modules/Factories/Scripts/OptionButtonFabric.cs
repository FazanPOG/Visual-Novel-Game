using System.Collections.Generic;
using Source.Modules.Dialogue.Scripts;
using Source.Modules.Factories.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Modules.Factories.Scripts
{
    public class OptionButtonFabric : IOptionButtonFabric
    {
        private readonly DialogueContainer _dialogueContainer;
        private readonly DialogueOption _prefab;
        private readonly Transform _parentTransform;
        private readonly DiContainer _diContainer;

        private List<DialogueOption> _options = new List<DialogueOption>();
        
        [Inject]
        public OptionButtonFabric(DialogueContainer dialogueContainer, DialogueOption prefab, Transform parentTransform, DiContainer diContainer)
        {
            _dialogueContainer = dialogueContainer;
            _prefab = prefab;
            _parentTransform = parentTransform;
            _diContainer = diContainer;
        }
        
        public void Create(DialogueOptionSO dialogueOptionSo)
        {
            DialogueOption instance = _diContainer.InstantiatePrefabForComponent<DialogueOption>(_prefab, _parentTransform);

            instance.Init(dialogueOptionSo, _dialogueContainer);
            _options.Add(instance);
        }

        public void DestroyAllOptions()
        {
            foreach (var option in _options)
                GameObject.Destroy(option.gameObject);
            
            _options.Clear();
        }
    }
}
