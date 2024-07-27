using Source.Modules.Dialogue.Scripts;
using Source.Modules.Factories.Scripts;
using Source.Modules.Factories.Scripts.Interfaces;
using Source.Modules.GameRoot.Scripts;
using Source.Modules.GameRoot.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Modules.Installers.Scripts
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private DialogueContainer _dialogueContainer;
        [SerializeField] private DialogueOption _dialogueOptionPrefab;
        [SerializeField] private Transform _parentObject;

        public override void InstallBindings()
        {
            BindDialogueContainer();
            BindDialogueOptionPrefab();
            BindDialogueOptionParentTransform();
            BindOptionButtonFabric();
            BindGameStateMachine();
        }

        private void BindOptionButtonFabric() => Container.Bind<IOptionButtonFabric>().To<OptionButtonFabric>().AsSingle();
        private void BindDialogueOptionPrefab() => Container.Bind<DialogueOption>().FromInstance(_dialogueOptionPrefab).AsSingle();
        private void BindDialogueOptionParentTransform() => Container.Bind<Transform>().FromInstance(_parentObject).AsSingle();
        private void BindDialogueContainer() => Container.Bind<DialogueContainer>().FromInstance(_dialogueContainer).AsSingle();
        private void BindGameStateMachine() => Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();
    }
}
