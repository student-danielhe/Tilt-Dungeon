using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BackToMain : MonoBehaviour
{
    public GameObject audioPlayer = null;

    public void OnClickTile()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
    }
}
