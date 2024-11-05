using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        public GameOverState gameOverState;
        public PlayerController playerController;
        public LevelController levelController;
        public GameObject rootUI;
        public TMPro.TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            rootUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;

            levelController.onGameOver += OnGameOver;
            levelController.onScoreInc += OnScoreInc;

            OnScoreInc(0);
        }

       

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }

            if (playerController)
            {
                playerController.enabled = false;
            }
            
            if (levelController)
            {
                levelController.enabled = false;
                levelController.onGameOver -= OnGameOver;
                levelController.onScoreInc -= OnScoreInc;
            }
        }

        private void OnScoreInc(int score)
        {
            scoreText.text = $"SCORE: {score}";
        }

        private void OnGameOver(int score)
        {
            GameInstance.score = Mathf.Max(GameInstance.score, score);

            gameObject.SetActive(false);

            gameOverState.gameObject.SetActive(true);
        }
    }
}
