using System.Collections;
using TMPro;
using UnityEngine;

namespace Source.Modules.Dialogue.Scripts
{
    public class SmoothTextAppearanceAnimation : MonoBehaviour
    {
        private TextMeshProUGUI _textComponent;
        
        public void Init(TextMeshProUGUI textComponent)
        {
            _textComponent = textComponent;
        }
        
        public void PlayAnimation(string text, float duration = 4f)
        {
            StartCoroutine(SmoothAnimation(_textComponent, text, duration));
        }

        private IEnumerator SmoothAnimation(TextMeshProUGUI textComponent, string text, float duration)
        {
            textComponent.text = "";
            float totalCharacters = text.Length;
            float timePerCharacter = duration / totalCharacters;

            for (int i = 0; i < totalCharacters; i++)
            {
                textComponent.text += text[i];
                yield return new WaitForSeconds(timePerCharacter);
            }
        }
    }
}
