using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace VirtualMuseum
{
    public class SceneSystem : Singleton<SceneSystem>
    {
        [SerializeField]
        private GameObject blackScreen;


        public void LoadScene(string sceneName, bool fadeToBlack = true, float fadeSpeed = 1f)
        {
            PlayerPrefs.SetString("sceneName", sceneName);
            Debug.Log($"SceneSystem: Loading Scene => {sceneName}");
            StartCoroutine(
                FadeToBlack(
                    fadeToBlack,
                    () => {
                        SceneManager.LoadScene("Loading");
                    },
                    fadeSpeed
                )
            );
        }

        IEnumerator FadeToBlack(bool fadeToBlack, Action callback, float fadeSpeed)
        {
            Color color = blackScreen.GetComponent<Image>().color;
            float fadeAmount;

            if(fadeToBlack)
            {
                while(blackScreen.GetComponent<Image>().color.a < 1)
                {
                    var tempCol = blackScreen.GetComponent<Image>().color;
                    fadeAmount = tempCol.a + (fadeSpeed * Time.deltaTime);
                    var newColor = new Color(tempCol.r, tempCol.g, tempCol.b, fadeAmount);

                    blackScreen.GetComponent<Image>().color = newColor;
                    yield return null;
                    if(newColor.a >= 1) {
                        // SceneManager.LoadScene("Loading");
                        callback();
                    }
                }
            }
            else
            {
                while(blackScreen.GetComponent<Image>().color.a > 0)
                {
                    var tempCol = blackScreen.GetComponent<Image>().color;
                    fadeAmount = tempCol.a - (fadeSpeed * Time.deltaTime);
                    var newColor = new Color(tempCol.r, tempCol.g, tempCol.b, fadeAmount);

                    blackScreen.GetComponent<Image>().color = newColor;
                    yield return null;
                    if(newColor.a <= 0) {
                        // SceneManager.LoadScene("Loading");
                        callback();
                    }
                }
            }

            // yield return new WaitForSeconds(fadeSpeed);
            // SceneManager.LoadScene("Loading");
        }
    }
}