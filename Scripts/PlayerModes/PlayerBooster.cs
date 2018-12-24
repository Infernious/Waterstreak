using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBooster : MonoBehaviour {

    public ParticleSystem burstSystem;
    public float speedModifier = 1.5f;

    float duration;
    float originalSpeed;

    bool modeActivated;
    bool burstActivated;
    bool canPress;
    bool canDeactivate;

	// Use this for initialization
	void Start () {
        burstSystem.gameObject.SetActive(false);
        originalSpeed = FindObjectOfType<PlayerMovement>().moveSpeed; /// All thanks to Brackeys :)
        modeActivated = false;
        burstActivated = false;
        canPress = true;
        canDeactivate = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                burstSystem.gameObject.SetActive(true);
                modeActivated = true;
                duration = burstSystem.main.startLifetime.constant;
                canPress = false;
            }
        }

        if (duration >= 0f && Input.GetKeyDown(KeyCode.C) && canDeactivate == true)
        {
            burstSystem.gameObject.SetActive(false);
            modeActivated = false;
            canDeactivate = false;
            FindObjectOfType<PlayerMovement>().moveSpeed = originalSpeed;
        }
        else if (duration >= 0f && Input.GetKeyDown(KeyCode.B) && canDeactivate == false)
        {
            burstSystem.gameObject.SetActive(true);
            modeActivated = true;
            canDeactivate = true;
        }

        if (modeActivated)
            duration -= Time.deltaTime;

        if (duration <= 0f)
        {
            /// Set the player's move speed to the original speed set in the editor
            burstSystem.gameObject.SetActive(false);
            FindObjectOfType<PlayerMovement>().moveSpeed = originalSpeed;
            modeActivated = false;
            burstActivated = false;
        }
        else if (modeActivated == true && burstActivated == false)
        {
            FindObjectOfType<PlayerMovement>().moveSpeed *= speedModifier;
            ///modeActivated = true;
            burstActivated = true;
        }

        Debug.Log("Speed: " + FindObjectOfType<PlayerMovement>().moveSpeed.ToString() + " Lifetime: " + duration.ToString());
	}
}