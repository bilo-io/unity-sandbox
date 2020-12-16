using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  VirtualMuseum
{
    public class JumpPad : MonoBehaviour
    {
        public float jumpForce = 10f;
        // Start is called before the first frame update
        void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.name.Equals("Player"))
            {
                Debug.Log($"JumpPad: Applying force to : {other.name}");
                // other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
                var audio = gameObject.GetComponent<AudioSource>();
                audio?.Play();
                other.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection (Vector3.up * jumpForce);
            }
        }
    }


}