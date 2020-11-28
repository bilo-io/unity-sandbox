using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualMuseum {
  public class ActiveAtRange : MonoBehaviour {
    Transform mainCamTransform; // Stores the FPS camera transform
    private bool visible = true;
    public float distanceToAppear = 8;
    public float distance;
    public GameObject child;
    Renderer objRenderer;

    private void Start () {
      mainCamTransform = Camera.main.transform; //Get camera transform reference
      objRenderer = gameObject.GetComponentInChildren<Renderer> (); //Get render reference
    }
    private void Update () {
      disappearChecker ();
    }
    private void disappearChecker () {
      distance = Vector3.Distance (mainCamTransform.position, transform.position);

      // We have reached the distance to Enable Object
      if (distance < distanceToAppear) {
        if (!visible) {
          objRenderer.enabled = true; // Show Object
          child.SetActive (true);
          visible = true;
          Debug.Log ("Visible");
        }
      } else if (visible) {
        objRenderer.enabled = false; // Hide Object
        child.SetActive (false);
        visible = false;
        Debug.Log ("InVisible");
      }
    }
  }
}
