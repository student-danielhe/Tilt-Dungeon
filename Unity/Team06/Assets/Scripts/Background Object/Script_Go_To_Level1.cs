using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Go_To_Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        GameManager.instance.level1Unlocked = true;
        SceneManager.LoadScene("WangY_Level_1");
    }
}
