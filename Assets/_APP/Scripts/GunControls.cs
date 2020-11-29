using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour {
    public Animator animator;

    public string[] triggers = new string[]{
        "Shoot"
    };

    void Start () {
        animator = gameObject.GetComponent<Animator> ();
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Debug.Log ("LMB Down");
                animator.SetTrigger("Shoot");
                //  System.Random random = new System.Random();
                // int triggerIndex = random.Next(0, triggers.Length);
                // anim.SetTrigger(triggers[triggerIndex]);
            }
    }
}
