using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsPaused { get => isPaused; }

        [SerializeField]
        private bool isPaused;

        public void TogglePause()
        {
            isPaused = !isPaused;
            // Debug.Log($"GameManager.TogglePause() => isPaused: {isPaused}");
            if(isPaused) {
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }
        }

    }
}