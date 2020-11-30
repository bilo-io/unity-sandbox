using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    Transform mainCamTransform; // Stores the FPS camera transform
    public GameObject target;
    Renderer objRenderer;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float distanceToActive = 10;
    [SerializeField]
    private float distance;
    void Start()
    {
        mainCamTransform = Camera.main.transform; //Get camera transform reference
        objRenderer = target.GetComponentInChildren<Renderer> (); //Get render reference
    }


    // Update is called once per frame
    void Update()
    {

    }
}
