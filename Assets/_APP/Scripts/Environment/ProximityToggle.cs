using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityToggle : MonoBehaviour
{
    Transform mainCamTransform; // Stores the FPS camera transform
    public GameObject target;
    Renderer objRenderer;
    private bool visible = true;
    [SerializeField]
    private float distanceToActive = 10;
    [SerializeField]
    private float distance;
    [SerializeField]
    private bool requiresGaze = false;
    void Start()
    {
        mainCamTransform = Camera.main.transform; //Get camera transform reference
        objRenderer = target.GetComponentInChildren<Renderer> (); //Get render reference
    }

    // Update is called once per frame
    private void Update () {
      disappearChecker ();
    }
    private void disappearChecker () {
      distance = Vector3.Distance (mainCamTransform.position, transform.position);

      // We have reached the distance to Enable Object
      if (distance < distanceToActive) {
        if (!visible) {
          // objRenderer.enabled = true; // Show Object
          if(requiresGaze && IsInCameraView()) {
            target.SetActive(true);
            visible = true;
            Debug.Log ("Visible & InView");
          } else {
            target.SetActive(true);
            visible = true;
            Debug.Log ("Visible");
          }
        }
      } else if (visible) {
        // objRenderer.enabled = false; // Hide Object
        target.SetActive (false);
        visible = false;
        Debug.Log ("InVisible");
      }
    }

    private bool IsInCameraView() {
        Vector3 targetViewportPos = Camera.main.WorldToViewportPoint(target.transform.position);
        var threshold = 0.2f;
        var isInXRange = targetViewportPos.x > threshold && targetViewportPos.x < 1.0f - threshold;
        var isInYRange = targetViewportPos.y > threshold && targetViewportPos.y < 1.0f - threshold;

        return isInXRange && isInYRange && targetViewportPos.z > 0;
    }
}
