using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.Modules.Dialogue.Scripts
{
    public class DialogueTextHandler : MonoBehaviour, IPointerClickHandler
    {
        private TextMeshProUGUI _textComponent;

        private string _currentText;
        private bool _isAllTextShowed;

        public event Action OnNeedShowNextText;
        
        public void Init(TextMeshProUGUI textComponent)
        {
            _textComponent = textComponent;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(_isAllTextShowed == false)
                ShowAllText();
            else
                OnNeedShowNextText?.Invoke();
        }

        public void ShowText(string text, float animationDuration = 4f)
        {
            _currentText = text;
            PlaySmoothAppearanceAnimation(text, animationDuration);
            _isAllTextShowed = false;
        }
        
        private void PlaySmoothAppearanceAnimation(string text, float duration = 4f)
        {
            StartCoroutine(SmoothAnimation(_textComponent, text, duration));
        }

        private void ShowAllText()
        {
            StopAllCoroutines();
            _textComponent.text = _currentText;
            _isAllTextShowed = true;
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
            
            _isAllTextShowed = true;
        }
    }
}
