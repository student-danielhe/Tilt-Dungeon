using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu = null;
    public GameObject audioPlayer = null;
    public GameObject SettingMenu = null;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        SettingMenu.SetActive(false);
    }
    public void OnClickPause()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
    public void OnClickResume()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
    public void OnClickCalibrate()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        GameObject.FindWithTag("Player").GetComponent<Script_Player_Tilt>().Calibarate();
        pauseMenu.SetActive(false);
    }
    public void OnClickSetting()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        SettingMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void OnClickTile()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
    }
    public void OnClickRestart()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
