using TMPro;
using UnityEngine;

namespace KnowEncumbrance.Components
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject Title = null;
        private TMP_Text _TitleText = null;
        private string _originalTitleText = null;
        private Color _originalTitleColor;
        private bool _titleActive = false;
        
        public void Awake()
        {
            KnowEncumbrance.Log.LogDebug("InventoryManager Active!");
        }

        public void Start()
        {
            KnowEncumbrance.Log.LogDebug("InventoryManager Started!");

            if (Title != null)
            {
                _titleActive = true;
                _TitleText = Title.GetComponent<TMP_Text>();
                _originalTitleText = _TitleText.text;
                _originalTitleColor = _TitleText.color;
                InvokeRepeating(nameof(RefreshText),0.0f,0.4f);
            }
            else
            {
                KnowEncumbrance.Log.LogWarning($"Inventory Title Not Found");
            }
        }

        private void RefreshText()
        {
            if (!_titleActive)
                return;
            
            RefreshEndcumbranceText();
        } 

        public void RefreshEndcumbranceText()
        {
            _TitleText.text = $"{_originalTitleText} ({EncumbranceManager.Instance.GetCurrentEncumbrance()})";
            if (EncumbranceManager.Instance.IsEncumbered())
                _TitleText.color = Color.red;
            else
                _TitleText.color = _originalTitleColor;
        }
    }
}