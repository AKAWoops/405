using UnityEngine;
using UnityEngine.UI;

namespace Mark.Ballinger.GAM405
{
    public class MarbleUI : MonoBehaviour
    {
        
        private static MarbleUI _instance;
        public static MarbleUI Instance { get { return _instance; } }

        [SerializeField]
        private Text _timeText = null;

        [SerializeField]
        private Text _scoreText = null;

        [SerializeField]
        private Text _resultText = null;

        protected void Awake()
        {
            _instance = this;
        }

        // Some methods to display UI text
        
        public void ShowTime(float value)
        {
            value = Mathf.RoundToInt(value);
            _timeText.text = string.Format("Time: {0:00}", value);
        }

        public void ShowScore(int value)
        {
            _scoreText.text = string.Format("Score: {0:00}", value);
        }

        public void ShowResult(bool isWin)
        {
            if (isWin)
            {
                _resultText.text = string.Format(MarbleConstants.WinText);
            }
            else
            {
                _resultText.text = string.Format(MarbleConstants.LoseText);
            }
        }
    }
}