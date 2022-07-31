using UnityEngine;

namespace SAE.Mark.Ballinger.GAM405.Shared
{
    public class MarbleGame : MonoBehaviour
    {
        
        private static MarbleGame _instance;
        public static MarbleGame Instance { get { return _instance; } }

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                MarbleUI.Instance.ShowScore(_score);
            }
        }

        public float TimeLeft
        {
            get
            {
                return _timeLeft;
            }
            set
            {
                _timeLeft = value;
                MarbleUI.Instance.ShowTime(_timeLeft);
            }
        }

        public bool IsGameOver { get { return _isGameOver; } }

        private float _timeLeft = 0;
        private int _score = 0;
        private bool _isGameOver = false;

        protected void Awake()
        {
            _instance = this;
        }

        protected void Start()
        {
            Score = 0;
            TimeLeft = 30;
        }

        protected void Update()
        {
            if (_isGameOver)
            {
                return;
            }

            TimeLeft -= Time.deltaTime;

            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                EndTheGame(false);
            }
        }

        public void EndTheGame (bool isWin)
        {
            if (_isGameOver)
            {
                return;
            }

            _isGameOver = true;

            MarbleUI.Instance.ShowResult(isWin);
        }
    }
}