using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Script_Start_Menu : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject SettingButton;
    public GameObject AboutButton;
    public GameObject QuitButton;
    public float tiltReq = 10.0f;
    public GameObject audioPlayer = null;
    void Start(){
        if (GameManager.instance.firstime)
        {
            StartButton.SetActive(false);
            SettingButton.SetActive(false);
            AboutButton.SetActive(false);
            QuitButton.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            StartButton.SetActive(true);
            SettingButton.SetActive(true);
            AboutButton.SetActive(true);
            QuitButton.SetActive(true);
        }
        

    }
    void Update() {
        Vector3 rotation = Input.acceleration;
        rotation.x*=Mathf.Rad2Deg;
        rotation.y*=Mathf.Rad2Deg;
        rotation.z = 0;
        if (rotation.magnitude >= tiltReq)
        {
            gameObject.SetActive(false);
            StartButton.SetActive(true);
            SettingButton.SetActive(true);
            AboutButton.SetActive(true);
            QuitButton.SetActive(true);
            GameManager.instance.firstime = false;
        }
    }
    public void OnClickStart()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        SceneManager.LoadScene("Level_Select");
    }
    public void OnClickSetting()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        SceneManager.LoadScene("Setting");
    }
    public void OnClickAbout()
    {
        audioPlayer.GetComponent<Script_Audio_UI>().playButton();
        SceneManager.LoadScene("Credit");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }

}
