using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
/*When activated, displays a text messages, waits for some time,
then either exits play mode if in the editor,
or quits the application if not.*/

public class Script_Goal_Collide : MonoBehaviour
{
    public float EndGameDelay = 2.5f; //Amount of time to wait before exiting. Default to 2.5.
    public GameObject VictoryScreen = null;
    // Start is called before the first frame update
    GameObject audioPlayer = null;
    public string nextLevel = "Title";
    void Start()
    {
        VictoryScreen.SetActive(false);
        audioPlayer = GameObject.FindWithTag("AudioPlayer");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VictoryScreen.SetActive(true);
            audioPlayer.GetComponent<Script_Audio_Levels>().playVictory();
            Time.timeScale = 0.0f;
            if (nextLevel == "LinH_Level_2")
            {
                GameManager.instance.level2Unlocked = true;
            }
            if (nextLevel == "WangY_Level_3")
            {
                GameManager.instance.level3Unlocked = true;
            }
            if (nextLevel == "LinH_Level_4")
            {
                GameManager.instance.level4Unlocked = true;
            }
            if (nextLevel == "LinH_Level_5")
            {
                GameManager.instance.level5Unlocked = true;
            }
            if (nextLevel == "WangY_Level_6")
            {
                GameManager.instance.level6Unlocked = true;
            }
        }

        
    }
    public void NextLevel()
    {
        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(nextLevel);
    }
}
