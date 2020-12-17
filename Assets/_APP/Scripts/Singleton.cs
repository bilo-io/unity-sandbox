using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this as T;
            }
        }
    }
}
