using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaControls : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator> ();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Debug.Log ("Primary MouseButton Down");
            // anim.Play("KatanaSlice1");
            anim.SetTrigger("Attack");
        }

        if(Input.GetKeyDown(KeyCode.F)) {
            anim.SetTrigger("Attack2");
        }
    }
}
