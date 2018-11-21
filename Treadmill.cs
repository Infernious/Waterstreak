using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour {

    public float pushSpeed;

    public GameObject player;

    Rigidbody playerRB;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            playerRB.AddForceAtPosition(Vector3.left * pushSpeed, playerRB.position, ForceMode.Impulse);
    }
}
