using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public bool groundHit = false;

    bool printDone;

    bool gameWon = false;

    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        printDone = false;
        instance = this;
    }

    #endregion

    // Update is called once per frame
    void Update()
    {

        if (groundHit && !printDone)
        {
            print("Game Over...");
            printDone = true;
        }
    }

    public void EndGame()
    {
        if (gameWon == false)
        {
            gameWon = true;

            //TODO add game over mechanic 
        }
    }
}