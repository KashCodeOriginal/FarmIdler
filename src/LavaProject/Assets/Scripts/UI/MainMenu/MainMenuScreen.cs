using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuScreen : MonoBehaviour
    {
        public event Action OnPlayButtonClicked;

        [SerializeField] private Button _playButton;
    
        [SerializeField] private TMP_InputField _columnsInputField;
        [SerializeField] private TMP_InputField _rowsInputField;
    
        public int ColumnsValue
        {
            get
            {
                if (_columnsInputField.text == string.Empty)
                    return 0;

                return int.Parse(_columnsInputField.text);
            }
        }
        public int RowsValue
        {
            get
            {
                if(_rowsInputField.text == string.Empty)
                    return 0;

                return int.Parse(_rowsInputField.text);
            }
        }

        private void Start()
        {
            _playButton.onClick.AddListener(PlayButtonClick);
        }

        private void PlayButtonClick()
        {
            OnPlayButtonClicked?.Invoke();
        }
    }
}
