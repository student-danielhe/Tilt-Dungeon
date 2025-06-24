using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public float vol = 1.0f;
    public float tiltX = .0f;
    public float tiltY = .0f;
    public float tiltXDeg = 0;
    public float tiltYDeg = 0;
    public float caliberatedX = .0f;
    public float caliberatedY = .0f;
    public float tiltXUnadjusted = .0f;
    public float tiltYUnadjusted = .0f;
    public bool level1Unlocked = true;
    public bool level2Unlocked = false;
    public bool level3Unlocked = false;
    public bool level4Unlocked = false;
    public bool level5Unlocked = false;
    public bool level6Unlocked = false;
    public bool firstime = true;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
