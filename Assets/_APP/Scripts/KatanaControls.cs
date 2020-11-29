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
        if (Input.GetMouseButtonDown (1)) {
            Debug.Log ("RMB Down");
             System.Random random = new System.Random();
            int triggerIndex = random.Next(0, 5);//triggers.Length);
            Debug.Log($"{triggerIndex}: {triggers[triggerIndex]}");
            animator.SetTrigger(triggers[triggerIndex]);
            // weaponTrail.SetActive(true);
            // weaponTrail.Play();
            weaponTrail.enableEmission = true;
        }

        if(!AnimatorIsPlaying()) {
          // weaponTrail.SetActive(false);
          // weaponTrail.Stop();
          weaponTrail.enableEmission = false;
        }
    }

    bool AnimatorIsPlaying(){
         return animator.GetCurrentAnimatorStateInfo(0).length >
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
     }
}
