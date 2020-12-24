using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VirtualMuseum
{
    public class GameMenuController : MonoBehaviour
    {

        [SerializeField]
        private GameObject content;
        [SerializeField]
        private TextMeshProUGUI[] menuItems;
        [SerializeField]
        private int activeIndex;
        private float defaultX;
        private Color32 defaultColor;

        void Awake()
        {
            if(menuItems.Length > 0)
            {

                defaultX = menuItems[0].transform.position.x;
                defaultColor = menuItems[0].color;
                SetActiveItem();
            }

            content.SetActive(GameManager.instance.IsPaused);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.TogglePause();
                content.SetActive(GameManager.instance.IsPaused);
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                NextItem();
                SetActiveItem();
            }

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                PreviousItem();
                SetActiveItem();
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                SelectItem();
            }
        }

        void NextItem()
        {
            activeIndex++;
            if(activeIndex >= menuItems.Length)
            {
                activeIndex = 0;
            }
        }

        void PreviousItem()
        {
            activeIndex--;
            if(activeIndex < 0)
            {
                activeIndex = menuItems.Length - 1;
            }
        }

        void SetActiveItem()
        {
            for(int i = 0 ; i < menuItems.Length ; i++)
            {
                if(i == activeIndex)
                {
                    // menuItem.rectTransform.position.x = -300;
                    menuItems[i].color = new Color32(255,255,255,255);
                    menuItems[i].fontSize = 50;
                }
                else
                {
                    // menuItem.rectTransform.position.x = defaultX;
                    menuItems[i].color = defaultColor;
                    menuItems[i].fontSize = 30;
                }
            }
        }
        void TogglePause()
        {
            GameManager.instance.TogglePause();
            content.SetActive(GameManager.instance.IsPaused);
        }

        void SelectItem()
        {
            var itemName = menuItems[activeIndex].text;
            Debug.Log($"ItemName: {itemName}");

            switch(itemName) {
                case "Continue":
                    TogglePause();
                    break;

                case "Restart":
                    TogglePause();
                    SceneSystem.instance.ReloadScene();
                    break;

                case "Quit":
                    TogglePause();
                    SceneSystem.instance.LoadScene("Main");
                    break;

                default:
                    TogglePause();
                    break;
            }
        }
    }
}