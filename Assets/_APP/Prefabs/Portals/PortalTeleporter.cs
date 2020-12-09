﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {
  public Transform player;
  public Transform receiver;
  public float rotationDiffOffset = 180;
  public bool playerIsOverlapping = false;

  void Update () {
    if (playerIsOverlapping) {
      Vector3 portalToPlayer = player.position = transform.position;
      float dotProduct = Vector3.Dot (transform.up, portalToPlayer);

      if (dotProduct < 0f || true) {
        Debug.Log ("Teleporting Player");
        float rotationDiff = -Quaternion.Angle (transform.rotation, receiver.rotation);
        rotationDiff += rotationDiffOffset;
        player.Rotate (Vector3.up, rotationDiff);

        Vector3 positionOffset = Quaternion.Euler (0f, rotationDiff, 0f) * portalToPlayer;
        // player.position = receiver.position + positionOffset;
        player.position = receiver.position;
        playerIsOverlapping = false;
      }
    }
  }

  void OnTriggerEnter (Collider other) {
    if (other.tag == "Player") {
      playerIsOverlapping = true;
    }
  }

  private void OnTriggerExit (Collider other) {
    if (other.tag == "Player") {
      playerIsOverlapping = false;
    }
  }
}
