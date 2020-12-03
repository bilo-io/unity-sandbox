using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject child;

    private void OnTriggerEnter(Collider other) {
        child.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        child.SetActive(false);
    }
}
