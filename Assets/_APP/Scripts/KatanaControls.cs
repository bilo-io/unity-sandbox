using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaControls : MonoBehaviour {
    public ParticleSystem weaponTrail;
    public Animator animator;
    public string[] triggers = new string[]{
        "Slice_Horizontal_LR",
        "Slice_Horizontal_RL",
        "Slice_Double_V",
        "Slice_Double_X",
        "Stab"
    };

    void Start () {
        animator = gameObject.GetComponent<Animator> ();
    }

    void Update () {
        // Slice
        if (Input.GetMouseButtonDown (1)) {
            Debug.Log ("Anim=>Katana: Slice");
             System.Random random = new System.Random();
            int triggerIndex = random.Next(0, triggers.Length);
            Debug.Log($"{triggerIndex}: {triggers[triggerIndex]}");
            animator.SetTrigger(triggers[triggerIndex]);
            weaponTrail.enableEmission = true;
        }

        if(!AnimatorIsPlaying()) {
          weaponTrail.enableEmission = false;
        }


        // Jump
        if(Input.GetKeyDown(KeyCode.Space)) {
          Debug.Log("Anim=>Katana: Jumping");
          animator.SetTrigger("Jump");
        }

        // Run
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.Log("Anim=>Katana: IsRunning");
            animator.SetBool("IsRunning", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
          Debug.Log("Anim=>Katana: Walking");
          animator.SetBool("IsRunning", false);
        }
    }

    bool AnimatorIsPlaying(){
         return animator.GetCurrentAnimatorStateInfo(0).length >
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
     }
}
