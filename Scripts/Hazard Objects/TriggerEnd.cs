using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{

    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            GameManager.instance.groundHit = true;
        }
    }
}