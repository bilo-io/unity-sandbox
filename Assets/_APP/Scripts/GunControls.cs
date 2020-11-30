using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour {
    public Animator animator;
    public ParticleSystem muzzleFlash;

    public string[] triggers = new string[]{
        "Shoot"
    };

    void Start () {
        animator = gameObject.GetComponent<Animator> ();
    }

    void Update () {
        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Anim=>Gun: Shoot");
            animator.SetTrigger("Shoot");

            StartCoroutine(PlayMuzzleFlash());
        }

        // Jump
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Anim=>Gun: Jumping");
            animator.SetTrigger("Jump");
        }

        // Run
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.Log("Anim=>Gun: IsRunning");
            animator.SetBool("IsRunning", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
          Debug.Log("Anim=>Gun: Walking");
          animator.SetBool("IsRunning", false);
        }
    }

    IEnumerator PlayMuzzleFlash() {
      muzzleFlash.Play();
        // yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.2f  );
        muzzleFlash.Stop();
    }

    bool AnimatorIsPlaying(){
         return animator.GetCurrentAnimatorStateInfo(0).length >
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
