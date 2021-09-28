using System;
using TMPro;
using UnityEngine;
using IG;
using UnityEngine.Events;

namespace Kosmos6
{
    public class ManagerScore : SingletonManager<ManagerScore>
    {
        public int Score;
        public TextMeshProUGUI ScoreText;
        public Action<int> OnAddScore;
        public Action<int> OnNewScore;
        public UnityEvent<int> EventAddScore;

        void Start()
        {
            if (ScoreText == null)
            {
                Debug.LogError("ManagerScore. ScoreText null");
            }
            else
            {
                ScoreText.text = Score.ToString();
            }
        }

        private void OnEnable()
        {
            OnAddScore += IncreaseScore;
        }

        private void OnDisable()
        {
            OnAddScore -= IncreaseScore;
        }

        public void AddScore(int scoreDelta)
        {
            if (DebugMode)
            {
                Debug.Log("AddScore", this);
            }
            OnAddScore?.Invoke(scoreDelta);
        }

        public void IncreaseScore(int scoreDelta)
        {
            Score += scoreDelta;
            ScoreText.text = Score.ToString();
            OnNewScore(Score);
            EventAddScore.Invoke(scoreDelta);
        }

        public void ReactOnAddScore()
        {
            Debug.Log("ReactOnAddScore");
        }
    }
}
