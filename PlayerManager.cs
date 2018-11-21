using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int playerHP;

    public float burstModeDuration;

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}