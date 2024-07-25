using Source.Modules.Dialogue.Scripts;

namespace Source.Modules.Factories.Scripts.Interfaces
{
    public interface IOptionButtonFabric
    {
        void Create(DialogueOptionSO dialogueOptionSo);
        void DestroyAllOptions();
    }
}
