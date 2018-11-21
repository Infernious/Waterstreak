using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public float launchSpeed;

    public GameObject player;

    Rigidbody playerRB;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            playerRB.AddForceAtPosition(Vector3.up * launchSpeed, playerRB.position, ForceMode.Impulse);
            //playerRB.AddForce(Vector3.up * launchSpeed, ForceMode.Force);
    }
}
