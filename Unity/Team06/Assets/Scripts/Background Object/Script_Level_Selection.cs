using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Level_selection : MonoBehaviour
{
    public string Level1_Name = "Level 1";
    public string Level2_Name = "Level 2";
    public string Level3_Name = "Level 3";
    public string Level4_Name = "Level 4";
    public string Level5_Name = "Level 5";
    public string Level6_Name = "Level 6";
    public string Title_Name = "Title";


    public GameObject Level2_Scene = null;
    public GameObject Level3_Scene = null;
    public GameObject Level4_Scene = null;
    public GameObject Level5_Scene = null;
    public GameObject Level6_Scene = null;


    public GameObject Level2_Lock = null;
    public GameObject Level3_Lock = null;
    public GameObject Level4_Lock = null;
    public GameObject Level5_Lock = null;
    public GameObject Level6_Lock = null;
    public void Awake()
    {
        
        
        if (!GameManager.instance.level2Unlocked)
        {
            Level2_Scene.SetActive(false);
        }
        else
        {
            Level2_Lock.SetActive(false);
        }
        if (!GameManager.instance.level3Unlocked)
        {
            Level3_Scene.SetActive(false);
        }
        else
        {
            Level3_Lock.SetActive(false);
        }
        if (!GameManager.instance.level4Unlocked)
        {
            Level4_Scene.SetActive(false);
        }
        else
        {
            Level4_Lock.SetActive(false);
        }
        if (!GameManager.instance.level5Unlocked)
        {
            Level5_Scene.SetActive(false);
        }
        else
        {
            Level5_Lock.SetActive(false);
        }
        if (!GameManager.instance.level6Unlocked)
        {
            Level6_Scene.SetActive(false);
        }
        else
        {
            Level6_Lock.SetActive(false);
        }

    }

    public void goToLevel1()
    {
        SceneManager.LoadScene(Level1_Name);
    }
    public void goToLevel2()
    {
        SceneManager.LoadScene(Level2_Name);
    }
    public void goToLevel3()
    {
        SceneManager.LoadScene(Level3_Name);
    }
    public void goToLevel4()
    {
        SceneManager.LoadScene(Level4_Name);
    }
    public void goToLevel5()
    {
        SceneManager.LoadScene(Level5_Name);
    }
    public void goToLevel6()
    {
        SceneManager.LoadScene(Level6_Name);
    }
    public void goToTitle()
    {
        SceneManager.LoadScene(Title_Name);
    }
    public void goToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
