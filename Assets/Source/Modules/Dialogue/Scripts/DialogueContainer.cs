using TMPro;
using UnityEngine;

namespace Source.Modules.Dialogue.Scripts
{
    [RequireComponent(typeof(SmoothTextAppearanceAnimation))]
    public class DialogueContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        
        private SmoothTextAppearanceAnimation _animation;

        private void Awake() => _animation = GetComponent<SmoothTextAppearanceAnimation>();

        public void Init()
        {
            _animation.Init(_textComponent);
        }
        
        public void StartDialogue(DialogueSO dialogue)
        {
            
        }
    }
}
