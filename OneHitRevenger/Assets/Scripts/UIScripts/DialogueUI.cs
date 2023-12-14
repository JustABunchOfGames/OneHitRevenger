using SpecialLevelScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private GameObject DialogueArea;
        [SerializeField] private Text dialogueText;

        private void Awake()
        {
            ShowTextArea(false);
            TutorialLevel.textEvent.AddListener(SetTextArea);
        }

        public void SetTextArea(string text = "")
        {
            ShowTextArea(true, text);
        }

        private void ShowTextArea(bool show, string text = "")
        {
            DialogueArea.SetActive(show);
            dialogueText.text = text;
        }
    }
}