using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject child;

    [Header("Conditions")]
    [SerializeField]
    private bool childIsActive = false;
    [SerializeField]
    private bool OnInitDisable;

    [SerializeField]
    private bool OnExitDisable = true;

    [Header("Scaling")]
    [SerializeField]
    private bool ScaleOnToggle = true;
    private Vector3 originalScale;
    [SerializeField]
    private float scalingFrames;
    [SerializeField]
    private float scalingFramesLeft = 0;
    [SerializeField]
    private bool isScaling = false;
    private bool isScalingUp = false;

    private void Awake() {
        if(ScaleOnToggle) {
            originalScale = child.transform.localScale;
        }
        if(OnInitDisable) {
            child.SetActive(false);
            if(ScaleOnToggle) {
                child.transform.localScale = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        SetChildActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if(OnExitDisable) {
            SetChildActive(false);
        }
    }

    private void Update() {
        ScaleChild();
    }

    private void SetChildActive(bool isActive) {
        childIsActive = isActive;
        if(isActive) {
            child.SetActive(true);
            if(ScaleOnToggle) {
                isScaling = true;
                isScalingUp = true;
                scalingFramesLeft = scalingFrames;
            }
        } else {
            if(ScaleOnToggle) {
                isScaling = true;
                isScalingUp = false;
                scalingFramesLeft = scalingFrames;
            } else {
                child.SetActive(false);
            }
        }
    }
    private void ScaleChild() {
        if(ScaleOnToggle && isScaling && scalingFrames > 0) {
            scalingFramesLeft--;

            if(child.active) {
                var childScale = child.transform.localScale;

                var startScale = isScalingUp
                    ? Vector3.zero
                    : originalScale;
                var endScale = isScalingUp
                    ? originalScale
                    : Vector3.zero;
                child.transform.localScale = Vector3.Lerp(
                    child.transform.localScale,
                    endScale, Time.deltaTime * 2
                );
            }
        } else {
            isScaling = false;
            scalingFramesLeft = 0;
            child.SetActive(childIsActive);
        }
    }
}
