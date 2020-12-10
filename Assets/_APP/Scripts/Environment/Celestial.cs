using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celestial : MonoBehaviour {

	[SerializeField]
	private bool isOrbiting = false;
	[SerializeField]
	private GameObject orbitAnchor;
	[SerializeField]
	private float orbitSpeed = 1f;
	[SerializeField]
	private float orbitRadius;
	[SerializeField]
	private float rotationSpeed;

	void Start ()
	{
		isOrbiting = orbitAnchor != null;
	}
	
	void Update ()
	{
		if(isOrbiting)
        {
			transform.RotateAround(orbitAnchor.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
	}
}
