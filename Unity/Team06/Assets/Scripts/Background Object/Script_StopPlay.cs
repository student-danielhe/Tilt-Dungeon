using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StopPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = .0f;
    }

    // Update is called once per frame
   public void OnClick()
    {
        Time.timeScale = 1.0f;
        GameObject.FindWithTag("Player").GetComponent<Script_Player_Tilt>().Calibarate();
        GameObject.FindWithTag("Player").GetComponent<Script_Player_Movement>().stopped = false;
        Destroy(gameObject);
    }
}
