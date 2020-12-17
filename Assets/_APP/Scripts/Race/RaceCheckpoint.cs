using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum
{
    public class RaceCheckpoint : MonoBehaviour
    {
        [SerializeField]
        private bool isStart = false;

        [SerializeField]
        private bool isFinish = false;

        void OnTriggerEnter(Collider other)
        {
            if(other.name.Equals("Player"))
            {
                if(isStart)
                {
                    RaceManager.instance.StartRace();
                }
                else if(isFinish)
                {
                    RaceManager.instance.StopRace();
                }
                else
                {
                    RaceManager.instance.AddCheckpoint();
                }
            }
        }
    }
}
