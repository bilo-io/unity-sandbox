using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum
{
    public class MenuItem : MonoBehaviour
    {
        public GameObject Text;
        public string SceneName;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetActiveText(bool isActive)
        {
          Text.SetActive(isActive);
        }
    }
}
