using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace VirtualMuseum
{
    public class RaceManager : Singleton<RaceManager>
    {
        [SerializeField]
        private TextMeshProUGUI timer;
        [SerializeField]
        private float elapsedTime = 0;

        [SerializeField]
        private bool isTiming;

        public void Update()
        {
            if(isTiming)
            {
                elapsedTime += Time.deltaTime;
                TimeSpan ts = TimeSpan.FromSeconds(elapsedTime);
                String result = ts.ToString("m\\:ss\\.fff");
                timer.text = result;
            }
        }

        public void StartRace()
        {
            Debug.Log($"RaceManager.StartRace(): {""}");
            elapsedTime = 0f;
            isTiming = true;
        }

        public void StopRace()
        {
            Debug.Log($"RaceManager.StopRace(): {""}");
            isTiming = false;
        }

        public void AddCheckpoint()
        {
            Debug.Log($"RaceManager.AddCheckpoint(): {""}");
        }
    }
}
